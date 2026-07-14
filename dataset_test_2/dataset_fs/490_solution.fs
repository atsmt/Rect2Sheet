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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(200.000000, 200.000000) * millimeter, vector(67.200000, 200.000000) * millimeter, vector(67.200000, 190.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(96.794322, 96.229645, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(66.400000, 200.000000, 0.000000) * millimeter),
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
        var sketchRem1_0 = newSketchOnPlane(context, id + "sketchRem1_0", { "sketchPlane" : plane(vector(95.0, 200.0, -30.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0, "polyRem1_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(37.800000, -20.000000) * millimeter, vector(37.800000, -28.000000) * millimeter, vector(-95.000000, -28.000000) * millimeter, vector(-95.000000, 0.000000) * millimeter, vector(-105.000000, -2.000000) * millimeter, vector(-105.000000, 78.000000) * millimeter, vector(-95.000000, 80.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0);
        sheetMetalTab(context, id + "smTab1_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0"), vector(66.400000, 200.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0", EntityType.FACE), vector(66.400000, 200.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1_0 (two_bend) ===
        // Flange 1_0->3_1_0_2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_1_0_2a", {
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

        // Remaining polygon for tab 3_1_0_2
        var sketchRem3_1_0_2a = newSketchOnPlane(context, id + "sketchRem3_1_0_2a", { "sketchPlane" : plane(vector(-10.0, 210.0, -110.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3_1_0_2a, "polyRem3_1_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 80.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(-138.812500, -79.622300) * millimeter, vector(-132.521600, -88.654900) * millimeter, vector(-24.130400, -37.163700) * millimeter, vector(-30.421300, -28.131100) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_1_0_2a);
        sheetMetalTab(context, id + "smTab3_1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_1_0_2a"), vector(-10.000000, 205.000000, -70.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_3_1_0_2a", EntityType.FACE), vector(-10.000000, 205.000000, -70.000000) * millimeter),
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
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, -29.999996) * millimeter, vector(2.000000, -39.999980) * millimeter, vector(126.049800, -39.999980) * millimeter, vector(124.049800, -29.999996) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(208.000000, 0.000000) * millimeter, vector(208.000000, 119.999983) * millimeter, vector(0.000000, 119.999983) * millimeter, vector(0.000000, -29.999996) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_1_0_2_2b", EntityType.FACE), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_1 from 2 (one_bend) ===
        // Flange 2->1_1: bend=64.59deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(137.975100, 200.000000, -130.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 64.589962 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_1
        var wallFace1_1 = qClosestTo(qCreatedBy(id + "flange2_1_1", EntityType.FACE), vector(137.975100, 200.000000, -125.000000) * millimeter);
        var faceN1_1 = evPlane(context, { "face" : wallFace1_1 }).normal;
        var skN1_1 = dot(faceN1_1, vector(0.0, -1.0, 0.0)) >= 0 ? faceN1_1 : -faceN1_1;
        var sketchRem1_1 = newSketchOnPlane(context, id + "sketchRem1_1", { "sketchPlane" : plane(vector(200.0, 200.0, -30.0) * millimeter, skN1_1, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_1, "polyRem1_1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(95.000000, 0.000000) * millimeter, vector(95.000000, 80.000000) * millimeter, vector(124.049800, 90.000000) * millimeter, vector(124.049800, 98.000000) * millimeter, vector(0.000000, 98.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1);
        sheetMetalTab(context, id + "smTab1_1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1"), vector(137.975100, 200.000000, -30.000000) * millimeter),
            "booleanUnionScope" : wallFace1_1,
            "booleanOffset" : 0.0 * millimeter
        });
    });