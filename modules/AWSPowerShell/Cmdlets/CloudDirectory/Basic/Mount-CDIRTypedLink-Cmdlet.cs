/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Attaches a typed link to a specified source and target object. For more information,
    /// see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_links.html#directory_objects_links_typedlink">Typed
    /// Links</a>.
    /// </summary>
    [Cmdlet("Mount", "CDIRTypedLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudDirectory.Model.TypedLinkSpecifier")]
    [AWSCmdlet("Calls the Amazon Cloud Directory AttachTypedLink API operation.", Operation = new[] {"AttachTypedLink"}, SelectReturnType = typeof(Amazon.CloudDirectory.Model.AttachTypedLinkResponse))]
    [AWSCmdletOutput("Amazon.CloudDirectory.Model.TypedLinkSpecifier or Amazon.CloudDirectory.Model.AttachTypedLinkResponse",
        "This cmdlet returns an Amazon.CloudDirectory.Model.TypedLinkSpecifier object.",
        "The service call response (type Amazon.CloudDirectory.Model.AttachTypedLinkResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class MountCDIRTypedLinkCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A set of attributes that are associated with the typed link.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Attributes")]
        public Amazon.CloudDirectory.Model.AttributeNameAndValue[] Attribute { get; set; }
        #endregion
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the directory where you want to attach the typed
        /// link.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter TypedLinkFacet_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the schema. For more information,
        /// see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// ever share the same object identifier. To identify an object with ObjectIdentifier,
        /// the ObjectIdentifier must be wrapped in double quotes. </para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// ever share the same object identifier. To identify an object with ObjectIdentifier,
        /// the ObjectIdentifier must be wrapped in double quotes. </para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter TypedLinkFacet_TypedLinkName
        /// <summary>
        /// <para>
        /// <para>The unique name of the typed link facet.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TypedLinkFacet_TypedLinkName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TypedLinkSpecifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudDirectory.Model.AttachTypedLinkResponse).
        /// Specifying the name of a property of type Amazon.CloudDirectory.Model.AttachTypedLinkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TypedLinkSpecifier";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DirectoryArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DirectoryArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DirectoryArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Mount-CDIRTypedLink (AttachTypedLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudDirectory.Model.AttachTypedLinkResponse, MountCDIRTypedLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DirectoryArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attribute != null)
            {
                context.Attribute = new List<Amazon.CloudDirectory.Model.AttributeNameAndValue>(this.Attribute);
            }
            #if MODULAR
            if (this.Attribute == null && ParameterWasBound(nameof(this.Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DirectoryArn = this.DirectoryArn;
            #if MODULAR
            if (this.DirectoryArn == null && ParameterWasBound(nameof(this.DirectoryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceObjectReference_Selector = this.SourceObjectReference_Selector;
            context.TargetObjectReference_Selector = this.TargetObjectReference_Selector;
            context.TypedLinkFacet_SchemaArn = this.TypedLinkFacet_SchemaArn;
            #if MODULAR
            if (this.TypedLinkFacet_SchemaArn == null && ParameterWasBound(nameof(this.TypedLinkFacet_SchemaArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TypedLinkFacet_SchemaArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TypedLinkFacet_TypedLinkName = this.TypedLinkFacet_TypedLinkName;
            #if MODULAR
            if (this.TypedLinkFacet_TypedLinkName == null && ParameterWasBound(nameof(this.TypedLinkFacet_TypedLinkName)))
            {
                WriteWarning("You are passing $null as a value for parameter TypedLinkFacet_TypedLinkName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudDirectory.Model.AttachTypedLinkRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            
             // populate SourceObjectReference
            var requestSourceObjectReferenceIsNull = true;
            request.SourceObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestSourceObjectReference_sourceObjectReference_Selector = null;
            if (cmdletContext.SourceObjectReference_Selector != null)
            {
                requestSourceObjectReference_sourceObjectReference_Selector = cmdletContext.SourceObjectReference_Selector;
            }
            if (requestSourceObjectReference_sourceObjectReference_Selector != null)
            {
                request.SourceObjectReference.Selector = requestSourceObjectReference_sourceObjectReference_Selector;
                requestSourceObjectReferenceIsNull = false;
            }
             // determine if request.SourceObjectReference should be set to null
            if (requestSourceObjectReferenceIsNull)
            {
                request.SourceObjectReference = null;
            }
            
             // populate TargetObjectReference
            var requestTargetObjectReferenceIsNull = true;
            request.TargetObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestTargetObjectReference_targetObjectReference_Selector = null;
            if (cmdletContext.TargetObjectReference_Selector != null)
            {
                requestTargetObjectReference_targetObjectReference_Selector = cmdletContext.TargetObjectReference_Selector;
            }
            if (requestTargetObjectReference_targetObjectReference_Selector != null)
            {
                request.TargetObjectReference.Selector = requestTargetObjectReference_targetObjectReference_Selector;
                requestTargetObjectReferenceIsNull = false;
            }
             // determine if request.TargetObjectReference should be set to null
            if (requestTargetObjectReferenceIsNull)
            {
                request.TargetObjectReference = null;
            }
            
             // populate TypedLinkFacet
            var requestTypedLinkFacetIsNull = true;
            request.TypedLinkFacet = new Amazon.CloudDirectory.Model.TypedLinkSchemaAndFacetName();
            System.String requestTypedLinkFacet_typedLinkFacet_SchemaArn = null;
            if (cmdletContext.TypedLinkFacet_SchemaArn != null)
            {
                requestTypedLinkFacet_typedLinkFacet_SchemaArn = cmdletContext.TypedLinkFacet_SchemaArn;
            }
            if (requestTypedLinkFacet_typedLinkFacet_SchemaArn != null)
            {
                request.TypedLinkFacet.SchemaArn = requestTypedLinkFacet_typedLinkFacet_SchemaArn;
                requestTypedLinkFacetIsNull = false;
            }
            System.String requestTypedLinkFacet_typedLinkFacet_TypedLinkName = null;
            if (cmdletContext.TypedLinkFacet_TypedLinkName != null)
            {
                requestTypedLinkFacet_typedLinkFacet_TypedLinkName = cmdletContext.TypedLinkFacet_TypedLinkName;
            }
            if (requestTypedLinkFacet_typedLinkFacet_TypedLinkName != null)
            {
                request.TypedLinkFacet.TypedLinkName = requestTypedLinkFacet_typedLinkFacet_TypedLinkName;
                requestTypedLinkFacetIsNull = false;
            }
             // determine if request.TypedLinkFacet should be set to null
            if (requestTypedLinkFacetIsNull)
            {
                request.TypedLinkFacet = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.CloudDirectory.Model.AttachTypedLinkResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.AttachTypedLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cloud Directory", "AttachTypedLink");
            try
            {
                #if DESKTOP
                return client.AttachTypedLink(request);
                #elif CORECLR
                return client.AttachTypedLinkAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudDirectory.Model.AttributeNameAndValue> Attribute { get; set; }
            public System.String DirectoryArn { get; set; }
            public System.String SourceObjectReference_Selector { get; set; }
            public System.String TargetObjectReference_Selector { get; set; }
            public System.String TypedLinkFacet_SchemaArn { get; set; }
            public System.String TypedLinkFacet_TypedLinkName { get; set; }
            public System.Func<Amazon.CloudDirectory.Model.AttachTypedLinkResponse, MountCDIRTypedLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TypedLinkSpecifier;
        }
        
    }
}
