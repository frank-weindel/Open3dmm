namespace Open3dmm
{
    public enum FunctionNames : int
    {
        __WinMainCRTStartup = 0x004C5E88,
        __ioinit = 0x004C7850,
        __initmbctable = 0x004C7845,
        __setargv = 0x004C73B9,
        __setenvp = 0x004C72EE,
        __cinit = 0x004C6772,
        WinMain = 0x00427FB0,
        Malloc = 0x00419130,
        Free = 0x00419160,

        // StdCall
        AllocateGPT = 0x00429EE0,
        GDIFlush = 0x00429680,

        // ThisCall
        BWLD_Render = 0x00474590,
        BWLD_RenderBackground = 0x00474740,
        GOB__Method0045CD30 = 0x0045CD30,
        GOB__Method0045D0B0 = 0x0045D0B0,
        GOB__Method0045CFD0 = 0x0045CFD0,
        GPT__Method0042A550 = 0x0042A550,
        GPT__Method0042A700 = 0x0042A700,
        GPT__BlitMBMP = 0x0042B330,
        REGN_CopyRectAndReturnInvalid = 0x00426330,
        REGN_FUN_00426380 = 0x00426380,
        REGN_Offset = 0x00426300,
        REGN_FUN_004262A0 = 0x004262A0,
        Rectangle_HitTest = 0x0041A170,
        Rectangle_Copy = 0x0041A230,
        Rectangle_TopLeftOrigin = 0x0041A100,
        Rectangle_Offset = 0x0041A0E0,
        Rectangle_CopyAtOffset = 0x0041A0B0,
        Rectangle_Union = 0x00419D90,
        Rectangle_CalculateIntersectionBetween = 0x00419E10,
        Rectangle_CalculateIntersection = 0x00419E90,
        Rectangle_OneValidAndBothNotSame = 0x00419CF0,
        Rectangle_Transform = 0x00419F30,
        Rectangle_SizeLimit = 0x0041A250,
        MBMP_Blit = 0x00425300,
        MBMP_GetRect = 0x0043F7D0,
        MBMP_Method00425850 = 0x00425850,
        REGN_GetOrCreateGdiHandle = 0x00427D10,
        GPT__FromWindow = 0x00429CC0,
        GPT__FromHDC = 0x00429C60,
        BASE_Init = 0x004190F0,
        GPT__SetDC = 0x00429D10,
    }
}
