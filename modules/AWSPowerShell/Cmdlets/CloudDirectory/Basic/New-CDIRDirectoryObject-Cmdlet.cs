/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Creates an object in a <a>Directory</a>. Additionally attaches the object to a parent,
    /// if a parent reference and <c>LinkName</c> is specified. An object is simply a collection
    /// of <a>Facet</a> attributes. You can also use this API call to create a policy object,
    /// if the facet from which you create the object is a policy facet.
    /// </summary>
    [Cmdlet("New", "CDIRDirectoryObject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Cloud Directory CreateObject API operation.", Operation = new[] {"CreateObject"}, SelectReturnType = typeof(Amazon.CloudDirectory.Model.CreateObjectResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudDirectory.Model.CreateObjectResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudDirectory.Model.CreateObjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCDIRDirectoryObjectCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the <a>Directory</a> in which
        /// the object will be created. For more information, see <a>arns</a>.</para>
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
        
        #region Parameter LinkName
        /// <summary>
        /// <para>
        /// <para>The name of link that is used to attach this object to a parent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LinkName { get; set; }
        #endregion
        
        #region Parameter ObjectAttributeList
        /// <summary>
        /// <para>
        /// <para>The attribute map whose attribute ARN contains the key and attribute value as the
        /// map value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CloudDirectory.Model.AttributeKeyAndValue[] ObjectAttributeList { get; set; }
        #endregion
        
        #region Parameter SchemaFacet
        /// <summary>
        /// <para>
        /// <para>A list of schema facets to be associated with the object. Do not provide minor version
        /// components. See <a>SchemaFacet</a> for details.</para>
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
        [Alias("SchemaFacets")]
        public Amazon.CloudDirectory.Model.SchemaFacet[] SchemaFacet { get; set; }
        #endregion
        
        #region Parameter ParentReference_Selector
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
        public System.String ParentReference_Selector { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ObjectIdentifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudDirectory.Model.CreateObjectResponse).
        /// Specifying the name of a property of type Amazon.CloudDirectory.Model.CreateObjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ObjectIdentifier";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDIRDirectoryObject (CreateObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudDirectory.Model.CreateObjectResponse, NewCDIRDirectoryObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryArn = this.DirectoryArn;
            #if MODULAR
            if (this.DirectoryArn == null && ParameterWasBound(nameof(this.DirectoryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LinkName = this.LinkName;
            if (this.ObjectAttributeList != null)
            {
                context.ObjectAttributeList = new List<Amazon.CloudDirectory.Model.AttributeKeyAndValue>(this.ObjectAttributeList);
            }
            context.ParentReference_Selector = this.ParentReference_Selector;
            if (this.SchemaFacet != null)
            {
                context.SchemaFacet = new List<Amazon.CloudDirectory.Model.SchemaFacet>(this.SchemaFacet);
            }
            #if MODULAR
            if (this.SchemaFacet == null && ParameterWasBound(nameof(this.SchemaFacet)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaFacet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudDirectory.Model.CreateObjectRequest();
            
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            if (cmdletContext.LinkName != null)
            {
                request.LinkName = cmdletContext.LinkName;
            }
            if (cmdletContext.ObjectAttributeList != null)
            {
                request.ObjectAttributeList = cmdletContext.ObjectAttributeList;
            }
            
             // populate ParentReference
            var requestParentReferenceIsNull = true;
            request.ParentReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestParentReference_parentReference_Selector = null;
            if (cmdletContext.ParentReference_Selector != null)
            {
                requestParentReference_parentReference_Selector = cmdletContext.ParentReference_Selector;
            }
            if (requestParentReference_parentReference_Selector != null)
            {
                request.ParentReference.Selector = requestParentReference_parentReference_Selector;
                requestParentReferenceIsNull = false;
            }
             // determine if request.ParentReference should be set to null
            if (requestParentReferenceIsNull)
            {
                request.ParentReference = null;
            }
            if (cmdletContext.SchemaFacet != null)
            {
                request.SchemaFacets = cmdletContext.SchemaFacet;
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
        
        private Amazon.CloudDirectory.Model.CreateObjectResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.CreateObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cloud Directory", "CreateObject");
            try
            {
                return client.CreateObjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LinkName { get; set; }
            public List<Amazon.CloudDirectory.Model.AttributeKeyAndValue> ObjectAttributeList { get; set; }
            public System.String ParentReference_Selector { get; set; }
            public List<Amazon.CloudDirectory.Model.SchemaFacet> SchemaFacet { get; set; }
            public System.Func<Amazon.CloudDirectory.Model.CreateObjectResponse, NewCDIRDirectoryObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ObjectIdentifier;
        }
        
    }
}
