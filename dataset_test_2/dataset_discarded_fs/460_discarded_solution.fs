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
        var sketch0_0 = newSketchOnPlane(context, id + "sketch0_0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(0.000000, 286.000000) * millimeter, vector(3.313800, 307.000000) * millimeter, vector(3.313800, 317.000000) * millimeter, vector(187.977100, 317.000000) * millimeter, vector(187.977100, 307.000000) * millimeter, vector(190.000000, 286.000000) * millimeter, vector(190.000000, 148.000000) * millimeter, vector(0.000000, 148.000000) * millimeter, vector(0.000000, 286.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(95.076732, 232.249221, 0.000000) * millimeter),
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
        // Flange 0_0->3_0_0_1: bend=86.59deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 69.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 86.590036 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3_0_0_1
        var wallFace3_0_0_1a = qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_1a", EntityType.FACE), vector(-9.702600, 69.000000, 4.991147) * millimeter);
        var faceN3_0_0_1a = evPlane(context, { "face" : wallFace3_0_0_1a }).normal;
        var skN3_0_0_1a = dot(faceN3_0_0_1a, vector(-0.9982294992, 0.0, 0.0594799702)) >= 0 ? faceN3_0_0_1a : -faceN3_0_0_1a;
        var sketchRem3_0_0_1a = newSketchOnPlane(context, id + "sketchRem3_0_0_1a", { "sketchPlane" : plane(vector(-9.4052, 138.0, 9.9823) * millimeter, skN3_0_0_1a, vector(-0.0594799702, 0.0, -0.9982294992)) });
        skPolyline(sketchRem3_0_0_1a, "polyRem3_0_0_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000005, 0.000000) * millimeter, vector(8.000005, 138.000000) * millimeter, vector(0.000000, 138.000000) * millimeter, vector(-285.499401, -169.000000) * millimeter, vector(-283.499401, -179.000000) * millimeter, vector(-52.494487, -179.000000) * millimeter, vector(-54.494487, -169.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_1a);
        sheetMetalTab(context, id + "smTab3_0_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_1a"), vector(-9.702600, 138.000000, 4.991147) * millimeter),
            "booleanUnionScope" : wallFace3_0_0_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_1->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(0.706450, 317.000000, 179.678250) * millimeter),
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
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(17.0, 317.0, 63.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(158.000000, 0.000000) * millimeter, vector(158.000000, 222.000000) * millimeter, vector(0.559000, 231.381400) * millimeter, vector(-7.426841, 231.857237) * millimeter, vector(-21.167341, 1.261337) * millimeter, vector(-13.181500, 0.785400) * millimeter, vector(0.000000, 222.000000) * millimeter, vector(-13.686200, -53.000000) * millimeter, vector(-15.682659, -62.881037) * millimeter, vector(168.980641, -62.881037) * millimeter, vector(170.977100, -53.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(5.697597, 317.000000, 179.380843) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_0_0_1_1b", EntityType.FACE), vector(5.697597, 317.000000, 179.380843) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });