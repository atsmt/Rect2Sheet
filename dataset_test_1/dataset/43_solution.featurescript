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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(0.000000, -10.000000) * millimeter, vector(200.000000, -10.000000) * millimeter, vector(200.000000, 100.000000) * millimeter, vector(-10.000000, 100.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(95.434783, 45.217391, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0 (two_bend) ===
        // Flange 0->1_0_1: bend=8.54deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(100.000000, -10.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 8.543979 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_1
        var wallFace1_0_1a = qClosestTo(qCreatedBy(id + "flange0_1_0_1a", EntityType.FACE), vector(100.000000, -14.944511, -0.742843) * millimeter);
        var faceN1_0_1a = evPlane(context, { "face" : wallFace1_0_1a }).normal;
        var skN1_0_1a = dot(faceN1_0_1a, vector(0.0, 0.1485685166, -0.9889021164)) >= 0 ? faceN1_0_1a : -faceN1_0_1a;
        var sketchRem1_0_1a = newSketchOnPlane(context, id + "sketchRem1_0_1a", { "sketchPlane" : plane(vector(0.0, -19.8890211643, -1.4856851657) * millimeter, skN1_0_1a, vector(0.0, 0.9889021164, 0.1485685166)) });
        skPolyline(sketchRem1_0_1a, "polyRem1_0_1a", { "points" : [vector(8.000000, 0.000000) * millimeter, vector(8.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(-27.598711, 180.000000) * millimeter, vector(-35.598711, 180.000000) * millimeter, vector(-35.598711, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1a);
        sheetMetalTab(context, id + "smTab1_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1a"), vector(0.000000, -14.944511, -0.742843) * millimeter),
            "booleanUnionScope" : wallFace1_0_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1->1: bend=143.54deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, -57.070466, -7.071670) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 143.539101 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1b = qClosestTo(qCreatedBy(id + "flange1_0_1_1b", EntityType.FACE), vector(90.000000, -60.605699, -10.607505) * millimeter);
        var faceN1b = evPlane(context, { "face" : wallFace1b }).normal;
        var skN1b = dot(faceN1b, vector(0.0, 0.7071669837, -0.7070465735)) >= 0 ? faceN1b : -faceN1b;
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(0.0, -64.1409314708, -14.1433396741) * millimeter, skN1b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(180.000000, -8.000000) * millimeter, vector(180.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(90.000000, -64.140931, -14.143340) * millimeter),
            "booleanUnionScope" : wallFace1b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0 (two_bend) ===
        // Flange 0->1_0_2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 50.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0_2
        var sketchRem1_0_2a = newSketchOnPlane(context, id + "sketchRem1_0_2a", { "sketchPlane" : plane(vector(-10.0, 0.0, -10.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_2a, "polyRem1_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-298.229066, -245.031362) * millimeter, vector(-291.666316, -253.929750) * millimeter, vector(-113.698544, -162.674768) * millimeter, vector(-120.261293, -153.776379) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2a);
        sheetMetalTab(context, id + "smTab1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2a"), vector(-10.000000, 50.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_2a", EntityType.FACE), vector(-10.000000, 50.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, -208.302259, -214.682430) * millimeter),
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

        // Remaining polygon for tab 2
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(100.0, -162.6747676879, -125.6985436358) * millimeter, vector(0.0, -0.8898388639, 0.4562749131), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(108.000000, 0.000000) * millimeter, vector(108.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(-5.000000, -208.302259, -214.682430) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_2_2b", EntityType.FACE), vector(-5.000000, -208.302259, -214.682430) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });