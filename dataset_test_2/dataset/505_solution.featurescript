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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(200.000000, 160.000000) * millimeter, vector(128.000000, 190.000000) * millimeter, vector(128.000000, 200.000000) * millimeter, vector(72.000000, 200.000000) * millimeter, vector(72.000000, 190.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(100.000000, 91.494505, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(100.000000, 200.000000, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(0.0, 200.0, -30.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-72.000000, -20.000000) * millimeter, vector(-72.000000, -28.000000) * millimeter, vector(-128.000000, -28.000000) * millimeter, vector(-128.000000, -20.000000) * millimeter, vector(-200.000000, 0.000000) * millimeter, vector(-200.000000, 80.000000) * millimeter, vector(-173.716800, 90.000000) * millimeter, vector(-173.716800, 98.000000) * millimeter, vector(-55.333000, 98.000000) * millimeter, vector(-55.333000, 90.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(10.000000, 78.000000) * millimeter, vector(10.000000, -2.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(100.000000, 200.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(100.000000, 200.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_0 from 1 (one_bend) ===
        // Flange 1->2_0: bend=115.41deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(114.524900, 200.000000, -130.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 115.410038 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2_0
        var wallFace2_0 = qClosestTo(qCreatedBy(id + "flange1_2_0", EntityType.FACE), vector(114.524900, 204.516301, -132.145467) * millimeter);
        var faceN2_0 = evPlane(context, { "face" : wallFace2_0 }).normal;
        var skN2_0 = dot(faceN2_0, vector(0.0, 0.4290933942, 0.9032601281)) >= 0 ? faceN2_0 : -faceN2_0;
        var sketchRem2_0 = newSketchOnPlane(context, id + "sketchRem2_0", { "sketchPlane" : plane(vector(105.0, 236.1304, -147.1637) * millimeter, skN2_0, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_0, "polyRem2_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-49.667000, -29.999996) * millimeter, vector(-49.667000, -37.999980) * millimeter, vector(68.716800, -37.999980) * millimeter, vector(68.716800, -29.999996) * millimeter, vector(95.000000, 0.000000) * millimeter, vector(95.000000, 119.999983) * millimeter, vector(0.000000, 119.999983) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_0);
        sheetMetalTab(context, id + "smTab2_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_0"), vector(114.524900, 236.130387, -147.163727) * millimeter),
            "booleanUnionScope" : wallFace2_0,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_1 from 1 (two_bend) ===
        // Flange 1->1_1_2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 200.000000, -70.000000) * millimeter),
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

        // Remaining polygon for tab 1_1_2_1
        var sketchRem1_1_2_1a = newSketchOnPlane(context, id + "sketchRem1_1_2_1a", { "sketchPlane" : plane(vector(-10.0, 210.0, -110.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem1_1_2_1a, "polyRem1_1_2_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 80.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(-138.812500, -79.622300) * millimeter, vector(-132.521600, -88.654900) * millimeter, vector(-24.130400, -37.163700) * millimeter, vector(-30.421300, -28.131100) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2_1a);
        sheetMetalTab(context, id + "smTab1_1_2_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2_1a"), vector(-10.000000, 205.000000, -70.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_1_1_2_1a", EntityType.FACE), vector(-10.000000, 205.000000, -70.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2_1->2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_1_2_1b", {
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

        // Remaining polygon for tab 2_1
        var sketchRem2_1b = newSketchOnPlane(context, id + "sketchRem2_1b", { "sketchPlane" : plane(vector(0.0, 236.1304, -147.1637) * millimeter, vector(0.0, -0.4290933942, -0.9032601281), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_1b, "polyRem2_1b", { "points" : [vector(-95.000000, 0.000000) * millimeter, vector(-95.000000, 119.999983) * millimeter, vector(8.000000, 119.999983) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(-95.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_1b);
        sheetMetalTab(context, id + "smTab2_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_1b"), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_1_2_1_2_1b", EntityType.FACE), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });