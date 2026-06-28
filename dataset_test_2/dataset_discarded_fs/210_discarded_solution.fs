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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(210.000000, 0.000000) * millimeter, vector(210.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(95.000000, 80.000000, 0.000000) * millimeter),
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

        // === Child Tab 2_1 from 0 (two_bend) ===
        // Flange 0->1_0_2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 80.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0_2_1
        var sketchRem1_0_2_1a = newSketchOnPlane(context, id + "sketchRem1_0_2_1a", { "sketchPlane" : plane(vector(-10.0, 0.0, -10.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_2_1a, "polyRem1_0_2_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(-179.622300, 348.812500) * millimeter, vector(-186.654900, 344.521600) * millimeter, vector(-135.163700, 236.130400) * millimeter, vector(-128.131100, 240.421300) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2_1a);
        sheetMetalTab(context, id + "smTab1_0_2_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2_1a"), vector(-10.000000, 80.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_2_1a", EntityType.FACE), vector(-10.000000, 80.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2_1->2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_1_2_1b", {
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
        var sketchRem2_1b = newSketchOnPlane(context, id + "sketchRem2_1b", { "sketchPlane" : plane(vector(0.0, 236.1304, -147.1637) * millimeter, vector(0.0, 0.4290933942, 0.9032601281), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_1b, "polyRem2_1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-2.000000, -9.999984) * millimeter, vector(93.000000, -9.999984) * millimeter, vector(95.000000, 0.000000) * millimeter, vector(95.000000, 119.999983) * millimeter, vector(-8.000000, 119.999983) * millimeter, vector(-8.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_1b);
        sheetMetalTab(context, id + "smTab2_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_1b"), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_2_1_2_1b", EntityType.FACE), vector(-5.000000, 290.326000, -172.909300) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1 from 2_1 (one_bend) ===
        // Flange 2_1->1: bend=115.41deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 290.326000, -172.909300) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 115.410038 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1 = qClosestTo(qCreatedBy(id + "flange2_1_1", EntityType.FACE), vector(-5.000000, 290.326000, -172.909300) * millimeter);
        var faceN1 = evPlane(context, { "face" : wallFace1 }).normal;
        var skN1 = dot(faceN1, vector(0.0, 1.0, 0.0)) >= 0 ? faceN1 : -faceN1;
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(0.0, 200.0, -30.0) * millimeter, skN1, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(208.000000, 0.000000) * millimeter, vector(208.000000, 80.000000) * millimeter, vector(200.000000, 80.000000) * millimeter, vector(198.000000, 90.000000) * millimeter, vector(-2.000000, 90.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(-5.000000, 290.326000, -30.000000) * millimeter),
            "booleanUnionScope" : wallFace1,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_0 from 1 (two_bend) ===
        // Flange 1->1_1_2_0: bend=154.59deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2_0a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(210.000000, 200.000000, -70.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 154.589962 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_1_2_0
        var wallFace1_1_2_0a = qClosestTo(qCreatedBy(id + "flange1_1_1_2_0a", EntityType.FACE), vector(210.000000, 205.000000, -70.000000) * millimeter);
        var faceN1_1_2_0a = evPlane(context, { "face" : wallFace1_1_2_0a }).normal;
        var skN1_1_2_0a = dot(faceN1_1_2_0a, vector(-1.0, 0.0, 0.0)) >= 0 ? faceN1_1_2_0a : -faceN1_1_2_0a;
        var sketchRem1_1_2_0a = newSketchOnPlane(context, id + "sketchRem1_1_2_0a", { "sketchPlane" : plane(vector(210.0, 210.0, -110.0) * millimeter, skN1_1_2_0a, vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem1_1_2_0a, "polyRem1_1_2_0a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 80.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(-138.812500, -79.622300) * millimeter, vector(-132.521600, -88.654900) * millimeter, vector(-24.130400, -37.163700) * millimeter, vector(-30.421300, -28.131100) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2_0a);
        sheetMetalTab(context, id + "smTab1_1_2_0a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2_0a"), vector(210.000000, 205.000000, -110.000000) * millimeter),
            "booleanUnionScope" : wallFace1_1_2_0a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2_0->2_0: bend=83.55deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_0_2_0b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(210.000000, 290.326000, -172.909300) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 83.545352 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2_0
        var wallFace2_0b = qClosestTo(qCreatedBy(id + "flange1_1_2_0_2_0b", EntityType.FACE), vector(205.000000, 290.326000, -172.909300) * millimeter);
        var faceN2_0b = evPlane(context, { "face" : wallFace2_0b }).normal;
        var skN2_0b = dot(faceN2_0b, vector(0.0, 0.4290933942, 0.9032601281)) >= 0 ? faceN2_0b : -faceN2_0b;
        var sketchRem2_0b = newSketchOnPlane(context, id + "sketchRem2_0b", { "sketchPlane" : plane(vector(105.0, 236.1304, -147.1637) * millimeter, skN2_0b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_0b, "polyRem2_0b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(103.000000, 0.000000) * millimeter, vector(103.000000, 119.999983) * millimeter, vector(0.000000, 119.999983) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_0b);
        sheetMetalTab(context, id + "smTab2_0b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_0b"), vector(205.000000, 236.130400, -147.163700) * millimeter),
            "booleanUnionScope" : wallFace2_0b,
            "booleanOffset" : 0.0 * millimeter
        });
    });