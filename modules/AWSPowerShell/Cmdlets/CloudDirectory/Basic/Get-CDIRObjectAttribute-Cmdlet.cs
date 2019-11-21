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
    /// Retrieves attributes within a facet that are associated with an object.
    /// </summary>
    [Cmdlet("Get", "CDIRObjectAttribute")]
    [OutputType("Amazon.CloudDirectory.Model.AttributeKeyAndValue")]
    [AWSCmdlet("Calls the Amazon Cloud Directory GetObjectAttributes API operation.", Operation = new[] {"GetObjectAttributes"}, SelectReturnType = typeof(Amazon.CloudDirectory.Model.GetObjectAttributesResponse))]
    [AWSCmdletOutput("Amazon.CloudDirectory.Model.AttributeKeyAndValue or Amazon.CloudDirectory.Model.GetObjectAttributesResponse",
        "This cmdlet returns a collection of Amazon.CloudDirectory.Model.AttributeKeyAndValue objects.",
        "The service call response (type Amazon.CloudDirectory.Model.GetObjectAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCDIRObjectAttributeCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>List of attribute names whose values will be retrieved.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter ConsistencyLevel
        /// <summary>
        /// <para>
        /// <para>The consistency level at which to retrieve the attributes on an object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudDirectory.ConsistencyLevel")]
        public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
        #endregion
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the <a>Directory</a> where
        /// the object resides.</para>
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
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter SchemaFacet_FacetName
        /// <summary>
        /// <para>
        /// <para>The name of the facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaFacet_FacetName { get; set; }
        #endregion
        
        #region Parameter SchemaFacet_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the schema that contains the facet with no minor component. See <a>arns</a>
        /// and <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/schemas_inplaceschemaupgrade.html">In-Place
        /// Schema Upgrade</a> for a description of when to provide minor versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaFacet_SchemaArn { get; set; }
        #endregion
        
        #region Parameter ObjectReference_Selector
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Attributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudDirectory.Model.GetObjectAttributesResponse).
        /// Specifying the name of a property of type Amazon.CloudDirectory.Model.GetObjectAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Attributes";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AttributeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AttributeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AttributeName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudDirectory.Model.GetObjectAttributesResponse, GetCDIRObjectAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AttributeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AttributeName != null)
            {
                context.AttributeName = new List<System.String>(this.AttributeName);
            }
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConsistencyLevel = this.ConsistencyLevel;
            context.DirectoryArn = this.DirectoryArn;
            #if MODULAR
            if (this.DirectoryArn == null && ParameterWasBound(nameof(this.DirectoryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ObjectReference_Selector = this.ObjectReference_Selector;
            context.SchemaFacet_FacetName = this.SchemaFacet_FacetName;
            context.SchemaFacet_SchemaArn = this.SchemaFacet_SchemaArn;
            
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
            var request = new Amazon.CloudDirectory.Model.GetObjectAttributesRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeNames = cmdletContext.AttributeName;
            }
            if (cmdletContext.ConsistencyLevel != null)
            {
                request.ConsistencyLevel = cmdletContext.ConsistencyLevel;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            
             // populate ObjectReference
            var requestObjectReferenceIsNull = true;
            request.ObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestObjectReference_objectReference_Selector = null;
            if (cmdletContext.ObjectReference_Selector != null)
            {
                requestObjectReference_objectReference_Selector = cmdletContext.ObjectReference_Selector;
            }
            if (requestObjectReference_objectReference_Selector != null)
            {
                request.ObjectReference.Selector = requestObjectReference_objectReference_Selector;
                requestObjectReferenceIsNull = false;
            }
             // determine if request.ObjectReference should be set to null
            if (requestObjectReferenceIsNull)
            {
                request.ObjectReference = null;
            }
            
             // populate SchemaFacet
            var requestSchemaFacetIsNull = true;
            request.SchemaFacet = new Amazon.CloudDirectory.Model.SchemaFacet();
            System.String requestSchemaFacet_schemaFacet_FacetName = null;
            if (cmdletContext.SchemaFacet_FacetName != null)
            {
                requestSchemaFacet_schemaFacet_FacetName = cmdletContext.SchemaFacet_FacetName;
            }
            if (requestSchemaFacet_schemaFacet_FacetName != null)
            {
                request.SchemaFacet.FacetName = requestSchemaFacet_schemaFacet_FacetName;
                requestSchemaFacetIsNull = false;
            }
            System.String requestSchemaFacet_schemaFacet_SchemaArn = null;
            if (cmdletContext.SchemaFacet_SchemaArn != null)
            {
                requestSchemaFacet_schemaFacet_SchemaArn = cmdletContext.SchemaFacet_SchemaArn;
            }
            if (requestSchemaFacet_schemaFacet_SchemaArn != null)
            {
                request.SchemaFacet.SchemaArn = requestSchemaFacet_schemaFacet_SchemaArn;
                requestSchemaFacetIsNull = false;
            }
             // determine if request.SchemaFacet should be set to null
            if (requestSchemaFacetIsNull)
            {
                request.SchemaFacet = null;
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
        
        private Amazon.CloudDirectory.Model.GetObjectAttributesResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.GetObjectAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cloud Directory", "GetObjectAttributes");
            try
            {
                #if DESKTOP
                return client.GetObjectAttributes(request);
                #elif CORECLR
                return client.GetObjectAttributesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributeName { get; set; }
            public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
            public System.String DirectoryArn { get; set; }
            public System.String ObjectReference_Selector { get; set; }
            public System.String SchemaFacet_FacetName { get; set; }
            public System.String SchemaFacet_SchemaArn { get; set; }
            public System.Func<Amazon.CloudDirectory.Model.GetObjectAttributesResponse, GetCDIRObjectAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Attributes;
        }
        
    }
}
