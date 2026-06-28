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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(116.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, -10.000000) * millimeter, vector(116.000000, -10.000000) * millimeter, vector(116.000000, 175.000000) * millimeter, vector(65.000000, 194.000000) * millimeter, vector(65.000000, 204.000000) * millimeter, vector(0.473500, 204.000000) * millimeter, vector(0.473500, 194.000000) * millimeter, vector(0.000000, 175.000000) * millimeter, vector(0.000000, -10.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(59.507364, 92.934604, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(83.263250, 204.000000, 0.000000) * millimeter),
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
        var sketchRem1_0 = newSketchOnPlane(context, id + "sketchRem1_0", { "sketchPlane" : plane(vector(102.0, 204.0, 29.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_0, "polyRem1_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-102.000000, 0.000000) * millimeter, vector(-102.000000, 126.000000) * millimeter, vector(0.000000, 126.000000) * millimeter, vector(13.526500, -19.000000) * millimeter, vector(13.526500, -27.000000) * millimeter, vector(-51.000000, -27.000000) * millimeter, vector(-51.000000, -19.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0);
        sheetMetalTab(context, id + "smTab1_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0"), vector(83.263250, 204.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0", EntityType.FACE), vector(83.263250, 204.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1_1 from 0 (two_bend) ===
        // Flange 0->1_0_1_1: bend=125.41deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(58.000000, -10.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 125.411328 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_1_1
        var wallFace1_0_1_1a = qClosestTo(qCreatedBy(id + "flange0_1_0_1_1a", EntityType.FACE), vector(58.000000, -7.102788, 4.075066) * millimeter);
        var faceN1_0_1_1a = evPlane(context, { "face" : wallFace1_0_1_1a }).normal;
        var skN1_0_1_1a = dot(faceN1_0_1_1a, vector(0.0, 0.8150132545, -0.5794423138)) >= 0 ? faceN1_0_1_1a : -faceN1_0_1_1a;
        var sketchRem1_0_1_1a = newSketchOnPlane(context, id + "sketchRem1_0_1_1a", { "sketchPlane" : plane(vector(116.0, -4.2056, 8.1501) * millimeter, skN1_0_1_1a, vector(0.0, -0.5794423138, -0.8150132545)) });
        skPolyline(sketchRem1_0_1_1a, "polyRem1_0_1_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999960, 0.000000) * millimeter, vector(7.999960, 116.000000) * millimeter, vector(-357.319685, 116.000000) * millimeter, vector(-357.319685, 14.000000) * millimeter, vector(-349.319725, 14.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1_1a);
        sheetMetalTab(context, id + "smTab1_0_1_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1_1a"), vector(116.000000, -7.102788, 4.075066) * millimeter),
            "booleanUnionScope" : wallFace1_0_1_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1_1->1_1: bend=144.59deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(51.000000, 204.000000, 301.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 144.588672 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_1
        var wallFace1_1b = qClosestTo(qCreatedBy(id + "flange1_0_1_1_1_1b", EntityType.FACE), vector(51.000000, 204.000000, 296.000000) * millimeter);
        var faceN1_1b = evPlane(context, { "face" : wallFace1_1b }).normal;
        var skN1_1b = dot(faceN1_1b, vector(0.0, 1.0, 0.0)) >= 0 ? faceN1_1b : -faceN1_1b;
        var sketchRem1_1b = newSketchOnPlane(context, id + "sketchRem1_1b", { "sketchPlane" : plane(vector(102.0, 204.0, 165.0) * millimeter, skN1_1b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1_1b, "polyRem1_1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(102.000000, 0.000000) * millimeter, vector(102.000000, 134.000000) * millimeter, vector(0.000000, 134.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1b);
        sheetMetalTab(context, id + "smTab1_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1b"), vector(51.000000, 204.000000, 165.000000) * millimeter),
            "booleanUnionScope" : wallFace1_1b,
            "booleanOffset" : 0.0 * millimeter
        });
    });