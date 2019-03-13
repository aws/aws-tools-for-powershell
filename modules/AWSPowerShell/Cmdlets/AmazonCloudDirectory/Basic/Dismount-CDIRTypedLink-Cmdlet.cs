/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Detaches a typed link from a specified source and target object. For more information,
    /// see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_links.html#directory_objects_links_typedlink">Typed
    /// Links</a>.
    /// </summary>
    [Cmdlet("Dismount", "CDIRTypedLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Cloud Directory DetachTypedLink API operation.", Operation = new[] {"DetachTypedLink"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DirectoryArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudDirectory.Model.DetachTypedLinkResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DismountCDIRTypedLinkCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the directory where you want to detach the typed
        /// link.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter TypedLinkSpecifier_IdentityAttributeValue
        /// <summary>
        /// <para>
        /// <para>Identifies the attribute value to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_IdentityAttributeValues")]
        public Amazon.CloudDirectory.Model.AttributeNameAndValue[] TypedLinkSpecifier_IdentityAttributeValue { get; set; }
        #endregion
        
        #region Parameter TypedLinkFacet_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the schema. For more information,
        /// see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_TypedLinkFacet_SchemaArn")]
        public System.String TypedLinkFacet_SchemaArn { get; set; }
        #endregion
        
        #region Parameter SourceObjectReference_Selector
        /// <summary>
        /// <para>
        /// <para>A path selector supports easy selection of an object by the parent/child links leading
        /// to it from the directory root. Use the link names from each parent/child link to construct
        /// the path. Path selectors start with a slash (/) and link names are separated by slashes.
        /// For more information about paths, see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_access_objects.html">Access
        /// Objects</a>. You can identify an object in one of the following ways:</para><ul><li><para><i>$ObjectIdentifier</i> - An object identifier is an opaque string provided by Amazon
        /// Cloud Directory. When creating objects, the system will provide you with the identifier
        /// of the created object. An object’s identifier is immutable and no two objects will
        /// ever share the same object identifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_SourceObjectReference_Selector")]
        public System.String SourceObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter TargetObjectReference_Selector
        /// <summary>
        /// <para>
        /// <para>A path selector supports easy selection of an object by the parent/child links leading
        /// to it from the directory root. Use the link names from each parent/child link to construct
        /// the path. Path selectors start with a slash (/) and link names are separated by slashes.
        /// For more information about paths, see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_access_objects.html">Access
        /// Objects</a>. You can identify an object in one of the following ways:</para><ul><li><para><i>$ObjectIdentifier</i> - An object identifier is an opaque string provided by Amazon
        /// Cloud Directory. When creating objects, the system will provide you with the identifier
        /// of the created object. An object’s identifier is immutable and no two objects will
        /// ever share the same object identifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_TargetObjectReference_Selector")]
        public System.String TargetObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter TypedLinkFacet_TypedLinkName
        /// <summary>
        /// <para>
        /// <para>The unique name of the typed link facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_TypedLinkFacet_TypedLinkName")]
        public System.String TypedLinkFacet_TypedLinkName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DirectoryArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Dismount-CDIRTypedLink (DetachTypedLink)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DirectoryArn = this.DirectoryArn;
            if (this.TypedLinkSpecifier_IdentityAttributeValue != null)
            {
                context.TypedLinkSpecifier_IdentityAttributeValues = new List<Amazon.CloudDirectory.Model.AttributeNameAndValue>(this.TypedLinkSpecifier_IdentityAttributeValue);
            }
            context.TypedLinkSpecifier_SourceObjectReference_Selector = this.SourceObjectReference_Selector;
            context.TypedLinkSpecifier_TargetObjectReference_Selector = this.TargetObjectReference_Selector;
            context.TypedLinkSpecifier_TypedLinkFacet_SchemaArn = this.TypedLinkFacet_SchemaArn;
            context.TypedLinkSpecifier_TypedLinkFacet_TypedLinkName = this.TypedLinkFacet_TypedLinkName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudDirectory.Model.DetachTypedLinkRequest();
            
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            
             // populate TypedLinkSpecifier
            bool requestTypedLinkSpecifierIsNull = true;
            request.TypedLinkSpecifier = new Amazon.CloudDirectory.Model.TypedLinkSpecifier();
            List<Amazon.CloudDirectory.Model.AttributeNameAndValue> requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue = null;
            if (cmdletContext.TypedLinkSpecifier_IdentityAttributeValues != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue = cmdletContext.TypedLinkSpecifier_IdentityAttributeValues;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue != null)
            {
                request.TypedLinkSpecifier.IdentityAttributeValues = requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue;
                requestTypedLinkSpecifierIsNull = false;
            }
            Amazon.CloudDirectory.Model.ObjectReference requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference = null;
            
             // populate SourceObjectReference
            bool requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReferenceIsNull = true;
            requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector = null;
            if (cmdletContext.TypedLinkSpecifier_SourceObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector = cmdletContext.TypedLinkSpecifier_SourceObjectReference_Selector;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference.Selector = requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector;
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReferenceIsNull = false;
            }
             // determine if requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference should be set to null
            if (requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReferenceIsNull)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference = null;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference != null)
            {
                request.TypedLinkSpecifier.SourceObjectReference = requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference;
                requestTypedLinkSpecifierIsNull = false;
            }
            Amazon.CloudDirectory.Model.ObjectReference requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference = null;
            
             // populate TargetObjectReference
            bool requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReferenceIsNull = true;
            requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector = null;
            if (cmdletContext.TypedLinkSpecifier_TargetObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector = cmdletContext.TypedLinkSpecifier_TargetObjectReference_Selector;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference.Selector = requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector;
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReferenceIsNull = false;
            }
             // determine if requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference should be set to null
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReferenceIsNull)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference = null;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference != null)
            {
                request.TypedLinkSpecifier.TargetObjectReference = requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference;
                requestTypedLinkSpecifierIsNull = false;
            }
            Amazon.CloudDirectory.Model.TypedLinkSchemaAndFacetName requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet = null;
            
             // populate TypedLinkFacet
            bool requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull = true;
            requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet = new Amazon.CloudDirectory.Model.TypedLinkSchemaAndFacetName();
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn = null;
            if (cmdletContext.TypedLinkSpecifier_TypedLinkFacet_SchemaArn != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn = cmdletContext.TypedLinkSpecifier_TypedLinkFacet_SchemaArn;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet.SchemaArn = requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn;
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull = false;
            }
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName = null;
            if (cmdletContext.TypedLinkSpecifier_TypedLinkFacet_TypedLinkName != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName = cmdletContext.TypedLinkSpecifier_TypedLinkFacet_TypedLinkName;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet.TypedLinkName = requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName;
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull = false;
            }
             // determine if requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet should be set to null
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet = null;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet != null)
            {
                request.TypedLinkSpecifier.TypedLinkFacet = requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet;
                requestTypedLinkSpecifierIsNull = false;
            }
             // determine if request.TypedLinkSpecifier should be set to null
            if (requestTypedLinkSpecifierIsNull)
            {
                request.TypedLinkSpecifier = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.DirectoryArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudDirectory.Model.DetachTypedLinkResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.DetachTypedLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "DetachTypedLink");
            try
            {
                #if DESKTOP
                return client.DetachTypedLink(request);
                #elif CORECLR
                return client.DetachTypedLinkAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String DirectoryArn { get; set; }
            public List<Amazon.CloudDirectory.Model.AttributeNameAndValue> TypedLinkSpecifier_IdentityAttributeValues { get; set; }
            public System.String TypedLinkSpecifier_SourceObjectReference_Selector { get; set; }
            public System.String TypedLinkSpecifier_TargetObjectReference_Selector { get; set; }
            public System.String TypedLinkSpecifier_TypedLinkFacet_SchemaArn { get; set; }
            public System.String TypedLinkSpecifier_TypedLinkFacet_TypedLinkName { get; set; }
        }
        
    }
}
