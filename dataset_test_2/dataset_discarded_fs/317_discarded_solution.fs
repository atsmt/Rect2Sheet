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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(80.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, -50.000000) * millimeter, vector(46.911800, -50.000000) * millimeter, vector(46.911800, -40.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(80.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(0.000000, -50.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(42.136280, 40.336515, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(56.544100, -50.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0
        var sketchRem1_0 = newSketchOnPlane(context, id + "sketchRem1_0", { "sketchPlane" : plane(vector(45.0, -50.0, 30.0) * millimeter, vector(0.0, 1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0, "polyRem1_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(11.911800, -20.000000) * millimeter, vector(11.911800, -28.000000) * millimeter, vector(-35.000000, -28.000000) * millimeter, vector(-35.000000, 0.000000) * millimeter, vector(-45.000000, -2.000000) * millimeter, vector(-45.000000, 78.000000) * millimeter, vector(-35.000000, 80.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0);
        sheetMetalTab(context, id + "smTab1_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0"), vector(56.544100, -50.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0", EntityType.FACE), vector(56.544100, -50.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1_0 (two_bend) ===
        // Flange 1_0->3_1_0_2: bend=45.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, -50.000000, 70.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 45.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3_1_0_2
        var wallFace3_1_0_2a = qClosestTo(qCreatedBy(id + "flange1_0_3_1_0_2a", EntityType.FACE), vector(93.535534, -46.464466, 70.000000) * millimeter);
        var faceN3_1_0_2a = evPlane(context, { "face" : wallFace3_1_0_2a }).normal;
        var skN3_1_0_2a = dot(faceN3_1_0_2a, vector(-0.7071067812, 0.7071067812, 0.0)) >= 0 ? faceN3_1_0_2a : -faceN3_1_0_2a;
        var sketchRem3_1_0_2a = newSketchOnPlane(context, id + "sketchRem3_1_0_2a", { "sketchPlane" : plane(vector(97.0711, -42.9289, 30.0) * millimeter, skN3_1_0_2a, vector(-0.7071067812, -0.7071067812, 0.0)) });
        skPolyline(sketchRem3_1_0_2a, "polyRem3_1_0_2a", { "points" : [vector(8.000046, 0.000000) * millimeter, vector(8.000046, 80.000000) * millimeter, vector(-16.284226, 80.000000) * millimeter, vector(-16.284226, 0.000000) * millimeter, vector(8.000046, 0.000000) * millimeter] });
        skSolve(sketchRem3_1_0_2a);
        sheetMetalTab(context, id + "smTab3_1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_1_0_2a"), vector(93.535534, -46.464466, 30.000000) * millimeter),
            "booleanUnionScope" : wallFace3_1_0_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_1_0_2->2: bend=45.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(110.000000, -30.000000, 70.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 45.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange3_1_0_2_2b", EntityType.FACE), vector(110.000000, -25.000000, 70.000000) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(1.0, 0.0, 0.0)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(110.0, -20.0, 110.0) * millimeter, skN2b, vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(80.000000, -8.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(90.000000, -2.000000) * millimeter, vector(90.000000, 178.000000) * millimeter, vector(80.000000, 180.000000) * millimeter, vector(0.000000, 180.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(110.000000, -20.000000, 70.000000) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_1 from 2 (one_bend) ===
 // Coplanar tab 2->1_1 (bend=0.00deg) — sheetMetalTab only
        // Warning: Could not get plane for remaining polygon of tab 1_1
    });