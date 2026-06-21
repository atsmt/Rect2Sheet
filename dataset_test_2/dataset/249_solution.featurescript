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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 70.000000) * millimeter, vector(210.000000, 70.000000) * millimeter, vector(210.000000, 0.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(200.000000, -10.000000) * millimeter, vector(120.000000, -60.000000) * millimeter, vector(120.000000, -190.000000) * millimeter, vector(0.000000, -190.000000) * millimeter, vector(0.000000, 70.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(82.700579, -42.402812, 0.000000) * millimeter),
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

        // === Child Tab 2 from 0 (two_bend) ===
        // Flange 0->1_0_2: bend=33.69deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(210.000000, 35.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 33.690068 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_2
        var wallFace1_0_2a = qClosestTo(qCreatedBy(id + "flange0_1_0_2a", EntityType.FACE), vector(214.160251, 35.000000, -2.773501) * millimeter);
        var faceN1_0_2a = evPlane(context, { "face" : wallFace1_0_2a }).normal;
        var skN1_0_2a = dot(faceN1_0_2a, vector(-0.5547001962, 0.0, -0.8320502943)) >= 0 ? faceN1_0_2a : -faceN1_0_2a;
        var sketchRem1_0_2a = newSketchOnPlane(context, id + "sketchRem1_0_2a", { "sketchPlane" : plane(vector(218.3205, 0.0, -5.547) * millimeter, skN1_0_2a, vector(-0.8320502943, 0.0, 0.5547001962)) });
        skPolyline(sketchRem1_0_2a, "polyRem1_0_2a", { "points" : [vector(7.999996, 0.000000) * millimeter, vector(7.999996, 70.000000) * millimeter, vector(-24.055516, 70.000000) * millimeter, vector(-24.055516, 0.000000) * millimeter, vector(7.999996, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2a);
        sheetMetalTab(context, id + "smTab1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2a"), vector(214.160251, 0.000000, -2.773501) * millimeter),
            "booleanUnionScope" : wallFace1_0_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2->2: bend=56.31deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(240.000000, 35.000000, -20.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 56.309932 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange1_0_2_2b", EntityType.FACE), vector(240.000000, 35.000000, -25.000000) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(-1.0, 0.0, 0.0)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(240.0, 0.0, -30.0) * millimeter, skN2b, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(70.000000, -8.000000) * millimeter, vector(70.000000, 180.000000) * millimeter, vector(0.000000, 180.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(240.000000, 35.000000, -30.000000) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });
    });