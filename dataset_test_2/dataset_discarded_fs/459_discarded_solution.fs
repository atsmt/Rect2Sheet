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
        var sketch0_0 = newSketchOnPlane(context, id + "sketch0_0", { "sketchPlane" : plane(vector(100.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(-100.000000, 286.000000) * millimeter, vector(-96.686200, 307.000000) * millimeter, vector(-96.686200, 317.000000) * millimeter, vector(-10.853600, 317.000000) * millimeter, vector(-10.853600, 307.000000) * millimeter, vector(-10.000000, 286.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(-100.000000, 0.000000) * millimeter, vector(-100.000000, 286.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(45.076724, 158.057431, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0_0 (two_bend) ===
        // Flange 0_0->3_0_0_1: bend=111.61deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(145.000000, 296.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 111.614578 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3_0_0_1
        var wallFace3_0_0_1a = qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_1a", EntityType.FACE), vector(145.000000, 297.841806, 4.648414) * millimeter);
        var faceN3_0_0_1a = evPlane(context, { "face" : wallFace3_0_0_1a }).normal;
        var skN3_0_0_1a = dot(faceN3_0_0_1a, vector(0.0, 0.9296827928, -0.3683611066)) >= 0 ? faceN3_0_0_1a : -faceN3_0_0_1a;
        var sketchRem3_0_0_1a = newSketchOnPlane(context, id + "sketchRem3_0_0_1a", { "sketchPlane" : plane(vector(190.0, 299.6836, 9.2968) * millimeter, skN3_0_0_1a, vector(0.0, -0.3683611066, -0.9296827928)) });
        skPolyline(sketchRem3_0_0_1a, "polyRem3_0_0_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999970, 0.000000) * millimeter, vector(7.999970, 90.000000) * millimeter, vector(0.000000, 90.000000) * millimeter, vector(-37.008831, 173.000000) * millimeter, vector(-45.008801, 173.000000) * millimeter, vector(-45.008801, 15.000000) * millimeter, vector(-37.008831, 15.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_1a);
        sheetMetalTab(context, id + "smTab3_0_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_1a"), vector(190.000000, 297.841806, 4.648414) * millimeter),
            "booleanUnionScope" : wallFace3_0_0_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_1->1: bend=158.39deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(96.000000, 317.000000, 53.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 158.385422 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1b = qClosestTo(qCreatedBy(id + "flange3_0_0_1_1b", EntityType.FACE), vector(96.000000, 317.000000, 58.000000) * millimeter);
        var faceN1b = evPlane(context, { "face" : wallFace1b }).normal;
        var skN1b = dot(faceN1b, vector(0.0, -1.0, 0.0)) >= 0 ? faceN1b : -faceN1b;
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(17.0, 317.0, 63.0) * millimeter, skN1b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(10.890023, -8.000000) * millimeter, vector(72.146400, -53.000000) * millimeter, vector(72.146400, -65.000000) * millimeter, vector(-13.686200, -65.000000) * millimeter, vector(-13.686200, -53.000000) * millimeter, vector(0.000000, 222.000000) * millimeter, vector(158.000000, 222.000000) * millimeter, vector(158.000000, -8.000000) * millimeter, vector(10.890023, -8.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(96.000000, 317.000000, 63.000000) * millimeter),
            "booleanUnionScope" : wallFace1b,
            "booleanOffset" : 0.0 * millimeter
        });
    });