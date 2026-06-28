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

        // === Root Tab 0_0 ===
        var sketch0_0 = newSketchOnPlane(context, id + "sketch0_0", { "sketchPlane" : plane(vector(95.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(0.000000, 110.000000) * millimeter, vector(85.000000, 110.000000) * millimeter, vector(85.000000, -30.000000) * millimeter, vector(-25.147100, -30.000000) * millimeter, vector(-25.147100, -20.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(0.000000, 110.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(135.351732, 37.600779, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0_0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0_0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1 from 0_0 (one_bend) ===
        // Flange 0_0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(124.926450, -30.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(180.0, -30.0, -50.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, -48.000000) * millimeter, vector(-110.147100, -48.000000) * millimeter, vector(-110.147100, -40.000000) * millimeter, vector(-180.000000, 0.000000) * millimeter, vector(-180.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, -48.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(124.926450, -30.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_1", EntityType.FACE), vector(124.926450, -30.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0_0 (two_bend) ===
        // Flange 0_0->3_0_0_2: bend=14.04deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(137.500000, 110.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 14.036521 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 3_0_0_2
        var wallFace3_0_0_2a = qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_2a", EntityType.FACE), vector(137.500000, 114.850707, 1.212702) * millimeter);
        var faceN3_0_0_2a = evPlane(context, { "face" : wallFace3_0_0_2a }).normal;
        var skN3_0_0_2a = dot(faceN3_0_0_2a, vector(0.0, 0.2425403309, -0.9701413237)) >= 0 ? faceN3_0_0_2a : -faceN3_0_0_2a;
        var sketchRem3_0_0_2a = newSketchOnPlane(context, id + "sketchRem3_0_0_2a", { "sketchPlane" : plane(vector(180.0, 119.7014, 2.4254) * millimeter, skN3_0_0_2a, vector(0.0, -0.9701413237, -0.2425403309)) });
        skPolyline(sketchRem3_0_0_2a, "polyRem3_0_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999986, 0.000000) * millimeter, vector(7.999986, 85.000000) * millimeter, vector(0.000000, 85.000000) * millimeter, vector(-21.231084, 110.000000) * millimeter, vector(-29.231070, 110.000000) * millimeter, vector(-29.231070, 30.000000) * millimeter, vector(-21.231084, 30.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_2a);
        sheetMetalTab(context, id + "smTab3_0_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_2a"), vector(180.000000, 114.850707, 1.212702) * millimeter),
            "booleanUnionScope" : wallFace3_0_0_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_2->2: bend=104.04deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(110.000000, 150.000000, 10.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 104.036521 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange3_0_0_2_2b", EntityType.FACE), vector(110.000000, 150.000000, 15.000000) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(0.0, -1.0, 0.0)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(70.0, 150.0, 20.0) * millimeter, skN2b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(1.655200, -8.000000) * millimeter, vector(2.069000, -10.000000) * millimeter, vector(2.069000, -22.000000) * millimeter, vector(-53.490600, -22.000000) * millimeter, vector(-53.490600, -10.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(80.000000, 70.000000) * millimeter, vector(80.000000, -8.000000) * millimeter, vector(1.655200, -8.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(110.000000, 150.000000, 20.000000) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });
    });