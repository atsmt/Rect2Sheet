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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(65.000000, -10.000000) * millimeter, vector(65.000000, -20.000000) * millimeter, vector(95.000000, -20.000000) * millimeter, vector(95.000000, -10.000000) * millimeter, vector(140.000000, 0.000000) * millimeter, vector(140.000000, 110.000000) * millimeter, vector(0.000000, 110.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(70.382679, 50.704935, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(80.000000, -20.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(50.0, -20.0, -20.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(15.000000, -10.000000) * millimeter, vector(15.000000, -18.000000) * millimeter, vector(45.000000, -18.000000) * millimeter, vector(45.000000, -10.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(80.000000, 80.000000) * millimeter, vector(58.823500, 120.000000) * millimeter, vector(58.823500, 128.000000) * millimeter, vector(21.176500, 128.000000) * millimeter, vector(21.176500, 120.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(80.000000, -20.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(80.000000, -20.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0 (two_bend) ===
        // Flange 0->1_0_3: bend=137.49deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(70.000000, 110.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 137.489588 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_3
        var wallFace1_0_3a = qClosestTo(qCreatedBy(id + "flange0_1_0_3a", EntityType.FACE), vector(70.000000, 106.314227, -3.378621) * millimeter);
        var faceN1_0_3a = evPlane(context, { "face" : wallFace1_0_3a }).normal;
        var skN1_0_3a = dot(faceN1_0_3a, vector(0.0, -0.6757241757, 0.7371545553)) >= 0 ? faceN1_0_3a : -faceN1_0_3a;
        var sketchRem1_0_3a = newSketchOnPlane(context, id + "sketchRem1_0_3a", { "sketchPlane" : plane(vector(140.0, 102.6285, -6.7572) * millimeter, skN1_0_3a, vector(0.0, 0.7371545553, 0.6757241757)) });
        skPolyline(sketchRem1_0_3a, "polyRem1_0_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999938, 0.000000) * millimeter, vector(7.999938, 140.000000) * millimeter, vector(0.000000, 140.000000) * millimeter, vector(-142.788330, 90.000000) * millimeter, vector(-150.788268, 90.000000) * millimeter, vector(-150.788268, 10.000000) * millimeter, vector(-142.788330, 10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_3a);
        sheetMetalTab(context, id + "smTab1_0_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_3a"), vector(140.000000, 106.314227, -3.378621) * millimeter),
            "booleanUnionScope" : wallFace1_0_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_3->3: bend=47.49deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, -10.000000, -110.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 47.489588 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_0_3_3b", EntityType.FACE), vector(90.000000, -10.000000, -105.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, 1.0, 0.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(130.0, -10.0, -100.0) * millimeter, skN3b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(80.000000, -8.000000) * millimeter, vector(80.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(90.000000, -10.000000, -100.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (one_bend) ===
        // Flange 1->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, -20.000000, -150.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(130.0, -50.0, -150.0) * millimeter, vector(0.0, 0.0, -1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-21.176500, -20.000000) * millimeter, vector(-21.176500, -28.000000) * millimeter, vector(-58.823500, -28.000000) * millimeter, vector(-58.823500, -20.000000) * millimeter, vector(-80.000000, 0.000000) * millimeter, vector(-80.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(90.000000, -25.000000, -150.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2", EntityType.FACE), vector(90.000000, -25.000000, -150.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });