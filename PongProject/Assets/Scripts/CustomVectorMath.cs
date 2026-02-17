using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct MyVec2 {
    public float x, y;
    public MyVec2(float x, float y) { this.x = x; this.y = y; }
    
    // Helper to allow simple math like: myVec * 5.0f
    public static MyVec2 operator *(MyVec2 v, float scale) => NativeMath.Vector2Scale(v, scale);
}

[StructLayout(LayoutKind.Sequential)]
public struct MyVec3 {
    public float x, y, z;
    public MyVec3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
    
    public static MyVec3 operator *(MyVec3 v, float scale) => NativeMath.Vector3Scale(v, scale);
}

public static class NativeMath {
    // Ensure this matches your compiled .bundle or .dylib name exactly
    private const string DLL_NAME = "VectorMathematics"; 

    // ------- VECTOR 2 FUNCTIONS -------
    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Add(MyVec2 a, MyVec2 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Subtract(MyVec2 a, MyVec2 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Scale(MyVec2 v, float scale);

    [DllImport(DLL_NAME)]
    public static extern float Vector2Magnitude(MyVec2 v);

    [DllImport(DLL_NAME)]
    public static extern float Vector2MagnitudeSqr(MyVec2 v);

    [DllImport(DLL_NAME)]
    public static extern float Vector2Distance(MyVec2 a, MyVec2 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Normalize(MyVec2 v);

    [DllImport(DLL_NAME)]
    public static extern float Vector2Dot(MyVec2 a, MyVec2 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Reflect(MyVec2 v, MyVec2 normal);

    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Lerp(MyVec2 a, MyVec2 b, float t);

    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Perpendicular(MyVec2 v);

    [DllImport(DLL_NAME)]
    public static extern float Vector2Angle(MyVec2 a, MyVec2 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec2 Vector2Project(MyVec2 a, MyVec2 b);


    // ------- VECTOR 3 FUNCTIONS -------
    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Add(MyVec3 a, MyVec3 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Subtract(MyVec3 a, MyVec3 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Scale(MyVec3 v, float scale);

    [DllImport(DLL_NAME)]
    public static extern float Vector3Magnitude(MyVec3 v);

    [DllImport(DLL_NAME)]
    public static extern float Vector3MagnitudeSqr(MyVec3 v);

    [DllImport(DLL_NAME)]
    public static extern float Vector3Distance(MyVec3 a, MyVec3 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Normalize(MyVec3 v);
    
    [DllImport(DLL_NAME)]
    public static extern float Vector3Dot(MyVec3 a, MyVec3 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Cross(MyVec3 a, MyVec3 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Reflect(MyVec3 v, MyVec3 normal);

    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Lerp(MyVec3 a, MyVec3 b, float t);

    [DllImport(DLL_NAME)]
    public static extern float Vector3Angle(MyVec3 a, MyVec3 b);

    [DllImport(DLL_NAME)]
    public static extern MyVec3 Vector3Project(MyVec3 a, MyVec3 b);

    [DllImport(DLL_NAME)]
    public static extern float MathClamp(float value, float min, float max);
}