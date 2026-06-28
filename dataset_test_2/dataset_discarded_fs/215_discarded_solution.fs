FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(200.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(210.000000, 0.000000) * millimeter, vector(210.000000, 160.000000) * millimeter, vector(200.000000, 160.000000) * millimeter, vector(128.000000, 190.000000) * millimeter, vector(128.000000, 200.000000) * millimeter, vector(72.000000, 200.000000) * millimeter, vector(72.000000, 190.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(95.578947, 91.010526, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1_0 from 0 (one_bend) ===
        // Flange 0->1_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(100.000000, 200.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0
        var sketchRem1_0 = newSketchOnPlane(context, id + "sketchRem1_0", { "sketchPlane" : plane(vector(200.0, 200.0, -30.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0, "polyRem1_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(72.000000, -20.000000) * millimeter, vector(72.000000, -28.000000) * millimeter, vector(128.000000, -28.000000) * millimeter, vector(128.000000, -20.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(210.000000, -2.000000) * millimeter, vector(210.000000, 33.000000) * millimeter, vector(200.000000, 35.000000) * millimeter, vector(0.000000, 35.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0);
        sheetMetalTab(context, id + "smTab1_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0"), vector(100.000000, 200.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0", EntityType.FACE), vector(100.000000, 200.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_1 from 0 (two_bend) ===
        // Flange 0->1_0_1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 80.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_1_1
        var sketchRem1_0_1_1a = newSketchOnPlane(context, id + "sketchRem1_0_1_1a", { "sketchPlane" : plane(vector(-10.0, 160.0, -10.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_1_1a, "polyRem1_0_1_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(-100.000000, -30.000000) * millimeter, vector(-98.000000, -40.000000) * millimeter, vector(-63.000000, -40.000000) * millimeter, vector(-65.000000, -30.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1_1a);
        sheetMetalTab(context, id + "smTab1_0_1_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1_1a"), vector(-10.000000, 80.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_1_1a", EntityType.FACE), vector(-10.000000, 80.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1_1->1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 200.000000, -92.500000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_1
        var sketchRem1_1b = newSketchOnPlane(context, id + "sketchRem1_1b", { "sketchPlane" : plane(vector(200.0, 200.0, -75.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_1b, "polyRem1_1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(208.000000, 0.000000) * millimeter, vector(208.000000, 35.000000) * millimeter, vector(0.000000, 35.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1b);
        sheetMetalTab(context, id + "smTab1_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1b"), vector(-5.000000, 200.000000, -92.500000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_1_1_1_1b", EntityType.FACE), vector(-5.000000, 200.000000, -92.500000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1_0 (two_bend) ===
        // Flange 1_0->3_1_0_2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 200.000000, -47.500000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3_1_0_2
        var sketchRem3_1_0_2a = newSketchOnPlane(context, id + "sketchRem3_1_0_2a", { "sketchPlane" : plane(vector(-10.0, 210.0, -65.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3_1_0_2a, "polyRem3_1_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 35.000000) * millimeter, vector(0.000000, 35.000000) * millimeter, vector(-138.812500, -124.622300) * millimeter, vector(-132.521600, -133.654900) * millimeter, vector(-24.130400, -82.163700) * millimeter, vector(-30.421300, -73.131100) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_1_0_2a);
        sheetMetalTab(context, id + "smTab3_1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_1_0_2a"), vector(-10.000000, 205.000000, -47.500000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_3_1_0_2a", EntityType.FACE), vector(-10.000000, 205.000000, -47.500000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_1_0_2->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 290.326000, -172.909300) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(200.0, 236.1304, -147.1637) * millimeter, vector(0.0, -0.4290933942, -0.9032601281), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(208.000000, 0.000000) * millimeter, vector(208.000000, 119.999983) * millimeter, vector(0.000000, 119.999983) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_1_0_2_2b", EntityType.FACE), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });