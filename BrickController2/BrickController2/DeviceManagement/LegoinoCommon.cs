using System;
namespace BrickController2.DeviceManagement
{
    public enum HubPropertyOperation
    {
        SET_DOWNSTREAM = 0x01,
        ENABLE_UPDATES_DOWNSTREAM = 0x02,
        DISABLE_UPDATES_DOWNSTREAM = 0x03,
        RESET_DOWNSTREAM = 0x04,
        REQUEST_UPDATE_DOWNSTREAM = 0x05,
        UPDATE_UPSTREAM = 0x06,
    };

    public enum ControlPlusPortDeviceType
    {
        UNKNOWNDEVICE = 0,
        SIMPLE_MEDIUM_LINEAR_MOTOR = 1,
        TRAIN_MOTOR = 2,
        LIGHT = 8,
        VOLTAGE_SENSOR = 20,
        CURRENT_SENSOR = 21,
        PIEZO_BUZZER = 22,
        HUB_LED = 23,
        TILT_SENSOR = 34,
        MOTION_SENSOR = 35,
        COLOR_DISTANCE_SENSOR = 37,
        MEDIUM_LINEAR_MOTOR = 38,
        MOVE_HUB_MEDIUM_LINEAR_MOTOR = 39,
        MOVE_HUB_TILT_SENSOR = 40,
        DUPLO_TRAIN_BASE_MOTOR = 41,
        DUPLO_TRAIN_BASE_SPEAKER = 42,
        DUPLO_TRAIN_BASE_COLOR_SENSOR = 43,
        DUPLO_TRAIN_BASE_SPEEDOMETER = 44,
        TECHNIC_LARGE_LINEAR_MOTOR = 46,   // Technic Control+
        TECHNIC_XLARGE_LINEAR_MOTOR = 47,  // Technic Control+
        TECHNIC_MEDIUM_ANGULAR_MOTOR = 48, // Spike Prime
        TECHNIC_LARGE_ANGULAR_MOTOR = 49,  // Spike Prime
        TECHNIC_MEDIUM_HUB_GEST_SENSOR = 54,
        REMOTE_CONTROL_BUTTON = 55,
        REMOTE_CONTROL_RSSI = 56,
        TECHNIC_MEDIUM_HUB_ACCELEROMETER = 57,
        TECHNIC_MEDIUM_HUB_GYRO_SENSOR = 58,
        TECHNIC_MEDIUM_HUB_TILT_SENSOR = 59,
        TECHNIC_MEDIUM_HUB_TEMPERATURE_SENSOR = 60,
        TECHNIC_COLOR_SENSOR = 61,              // Spike Prime
        TECHNIC_DISTANCE_SENSOR = 62,           // Spike Prime
        TECHNIC_FORCE_SENSOR = 63,              // Spike Prime
        MARIO_HUB_GESTURE_SENSOR = 71,                 // https://github.com/bricklife/LEGO-Mario-Reveng
        MARIO_HUB_BARCODE_SENSOR = 73,          // https://github.com/bricklife/LEGO-Mario-Reveng
        MARIO_HUB_PANT_SENSOR = 74,             // https://github.com/bricklife/LEGO-Mario-Reveng
        TECHNIC_MEDIUM_ANGULAR_MOTOR_GREY = 75, // Mindstorms
        TECHNIC_LARGE_ANGULAR_MOTOR_GREY = 76   // Mindstorms
    };

    public enum Color
    {
        BLACK = 0,
        PINK = 1,
        PURPLE = 2,
        BLUE = 3,
        LIGHTBLUE = 4,
        CYAN = 5,
        GREEN = 6,
        YELLOW = 7,
        ORANGE = 8,
        RED = 9,
        WHITE = 10,
        NUM_COLORS,
        NONE = 255
    };

    public enum ButtonState
    {
        PRESSED = 0x01,
        RELEASED = 0x00,
        UP = 0x01,
        DOWN = 0xff,
        STOP = 0x7f
    };

    //https://github.com/bricklife/LEGO-Mario-Reveng/blob/master/IOType-0x4a.md
    public enum MarioPant
    {
        NONE = 0x00,
        PROPELLER = 0x0A,
        TANOOKI = 0x0C,
        CAT = 0x11,
        FIRE = 0x12,
        PENGUIN = 0x14,
        NORMAL = 0x21,
        BUILDER = 0x22
    };

    //https://github.com/bricklife/LEGO-Mario-Reveng/blob/master/IOType-0x49.md
    public enum MarioBarcode
    {
        NONE = 0xFF00,
        GOOMBA = 0x0200,
        REFRESH = 0x1400,
        QUESTION = 0x2900,
        CLOUD = 0x2E00,
        BAT = 0x7900,
        STAR = 0x7B00,
        KINGBOO = 0x8800,
        BOWSERJR = 0x9900,
        BOWSERGOAL = 0xB700,
        START = 0xB800
    };

    //https://github.com/bricklife/LEGO-Mario-Reveng/blob/master/IOType-0x49.md
    public enum MarioColor
    {
        NONE = 0xFFFF,
        WHITE = 0x1300,
        RED = 0x1500,
        BLUE = 0x1700,
        YELLOW = 0x1800,
        BLACK = 0x1A00,
        GREEN = 0x2500,
        BROWN = 0x6A00,
        PURPLE = 0x0C01,
        UNKNOWN = 0x3801,
        CYAN = 0x4201
    };

    //https://github.com/sharpbrick/powered-up
    public enum MarioGesture
    {
        NONE = 0x0000,
        BUMP = 0x0001,
        SHAKE = 0x0010,
        TURNING = 0x0100,
        FASTMOVE = 0x0200,
        TRANSLATION = 0x0400,
        HIGHFALLCRASH = 0x0800,
        DIRECTIONCHANGE = 0x1000,
        REVERSE = 0x2000,
        JUMP = 0x8000
    };


    public static class LegoinoCommon
    {

        public static readonly string[] COLOR_STRING = { "black", "pink", "purple", "blue", "lightblue", "cyan", "green", "yellow", "orange", "red", "white", "none" };

        public const double LPF2_VOLTAGE_MAX = 9.6;
        public const double LPF2_VOLTAGE_MAX_RAW = 3893;

        public const double LPF2_CURRENT_MAX = 2444;
        public const double LPF2_CURRENT_MAX_RAW = 4095;

        private static long map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        /**
         * @brief Map speed from -100..100 to the 8bit internal value
         * @param [in] speed -100..100
         */
        public static byte MapSpeed(int speed)
        {
            byte rawSpeed;
            if (speed == 0)
            {
                rawSpeed = 127; // stop motor
            }
            else if (speed > 0)
            {
                rawSpeed = (byte)map(speed, 0, 100, 0, 126);
            }
            else
            {
                rawSpeed = (byte)map(-speed, 0, 100, 255, 128);
            }
            return rawSpeed;
        }

        /**
         * @brief return string value of color enum
         * @param [in] Color enum
         */
        public static string ColorStringFromColor(Color color)
        {
            return ColorStringFromColor((int)color);
        }

        /**
         * @brief return string value of color enum
         * @param [in] Color int value
         */
        public static string ColorStringFromColor(int color)
        {
            if (color > (int)Color.NUM_COLORS)
            {
                return COLOR_STRING[(int)Color.NUM_COLORS];
            }
            else
            {
                return COLOR_STRING[color];
            }
        }

        public static byte[] Int16ToByteArray(short x)
        {
            byte[] y = new byte[2];
            y[0] = (byte)(x & 0xff);
            y[1] = (byte)((x >> 8) & 0xff);
            return y;
        }

        public static byte[] Int32ToByteArray(Int32 x)
        {
            byte[] y = new byte[4];
            y[0] = (byte)(x & 0xff);
            y[1] = (byte)((x >> 8) & 0xff);
            y[2] = (byte)((x >> 16) & 0xff);
            y[3] = (byte)((x >> 24) & 0xff);
            return y;
        }

        public static byte ReadUInt8(byte[] data, int offset = 0)
        {
            byte value = data[0 + offset];
            return value;
        }

        public static sbyte ReadInt8(byte[] data, int offset = 0)
        {
            sbyte value = (sbyte)data[0 + offset];
            return value;
        }

        public static ushort ReadUInt16LE(byte[] data, int offset = 0)
        {
            ushort value = (ushort)(data[0 + offset] | (ushort)(data[1 + offset] << 8));
            return value;
        }

        public static short ReadInt16LE(byte[] data, int offset = 0)
        {
            short value = (short)(data[0 + offset] | (short)(data[1 + offset] << 8));
            return value;
        }

        public static UInt32 ReadUInt32LE(byte[] data, int offset = 0)
        {
            UInt32 value = data[0 + offset] | (UInt32)(data[1 + offset] << 8) | (UInt32)(data[2 + offset] << 16) | (UInt32)(data[3 + offset] << 24);
            return value;
        }

        public static Int32 ReadInt32LE(byte[] data, int offset = 0)
        {
            Int32 value = (Int32)(data[0 + offset] | (short)(data[1 + offset] << 8) | (UInt32)(data[2 + offset] << 16) | (UInt32)(data[3 + offset] << 24));
            return value;
        }

    }
}
