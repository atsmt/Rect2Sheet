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
        skPolyline(sketch0, "poly0", { "points" : [vector(-10.000000, 191.000000) * millimeter, vector(558.000000, 191.000000) * millimeter, vector(558.000000, 0.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(-85.000000, 29.000000) * millimeter, vector(-190.000000, 29.000000) * millimeter, vector(-190.000000, 175.000000) * millimeter, vector(-95.000000, 175.000000) * millimeter, vector(-95.000000, 165.000000) * millimeter, vector(-85.000000, 165.000000) * millimeter, vector(-10.000000, 191.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(199.073761, 96.241843, 0.000000) * millimeter),
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

        // === Child Tab 3 from 2 (two_bend) ===
        // Flange 2->1_2_3: bend=135.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1_2_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-142.500000, 175.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 135.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_2_3
        var wallFace1_2_3a = qClosestTo(qCreatedBy(id + "flange2_1_2_3a", EntityType.FACE), vector(-142.500000, 178.535534, -3.535534) * millimeter);
        var faceN1_2_3a = evPlane(context, { "face" : wallFace1_2_3a }).normal;
        var skN1_2_3a = dot(faceN1_2_3a, vector(0.0, 0.7071067812, 0.7071067812)) >= 0 ? faceN1_2_3a : -faceN1_2_3a;
        var sketchRem1_2_3a = newSketchOnPlane(context, id + "sketchRem1_2_3a", { "sketchPlane" : plane(vector(-190.0, 182.0711, -7.0711) * millimeter, skN1_2_3a, vector(0.0, -0.7071067812, 0.7071067812)) });
        skPolyline(sketchRem1_2_3a, "polyRem1_2_3a", { "points" : [vector(8.000046, 0.000000) * millimeter, vector(8.000046, 95.000000) * millimeter, vector(-70.024341, 95.000000) * millimeter, vector(-70.024341, 0.000000) * millimeter, vector(8.000046, 0.000000) * millimeter] });
        skSolve(sketchRem1_2_3a);
        sheetMetalTab(context, id + "smTab1_2_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_2_3a"), vector(-190.000000, 178.535534, -3.535534) * millimeter),
            "booleanUnionScope" : wallFace1_2_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_2_3->3: bend=135.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-142.500000, 233.000000, -58.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 135.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_2_3_3b", EntityType.FACE), vector(-142.500000, 233.000000, -63.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, 1.0, 0.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(-190.0, 233.0, -68.0) * millimeter, skN3b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(95.000000, -8.000000) * millimeter, vector(95.000000, 136.000000) * millimeter, vector(0.000000, 136.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(-142.500000, 233.000000, -68.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });
    });