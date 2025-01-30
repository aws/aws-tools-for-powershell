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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Creates or updates the policy schema in the specified policy store. The schema is
    /// used to validate any Cedar policies and policy templates submitted to the policy store.
    /// Any changes to the schema validate only policies and templates submitted after the
    /// schema change. Existing policies and templates are not re-evaluated against the changed
    /// schema. If you later update a policy, then it is evaluated against the new schema
    /// at that time.
    /// 
    ///  <note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "AVPSchema", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.PutSchemaResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions PutSchema API operation.", Operation = new[] {"PutSchema"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.PutSchemaResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.PutSchemaResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.PutSchemaResponse object containing multiple properties."
    )]
    public partial class WriteAVPSchemaCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Definition_CedarJson
        /// <summary>
        /// <para>
        /// <para>A JSON string representation of the schema supported by applications that use this
        /// policy store. To delete the schema, run <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_PutSchema.html">PutSchema</a>
        /// with <c>{}</c> for this parameter. For more information, see <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/userguide/schema.html">Policy
        /// store schema</a> in the <i>Amazon Verified Permissions User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Definition_CedarJson { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store in which to place the schema.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.PutSchemaResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.PutSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AVPSchema (PutSchema)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.PutSchemaResponse, WriteAVPSchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Definition_CedarJson = this.Definition_CedarJson;
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VerifiedPermissions.Model.PutSchemaRequest();
            
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.VerifiedPermissions.Model.SchemaDefinition();
            System.String requestDefinition_definition_CedarJson = null;
            if (cmdletContext.Definition_CedarJson != null)
            {
                requestDefinition_definition_CedarJson = cmdletContext.Definition_CedarJson;
            }
            if (requestDefinition_definition_CedarJson != null)
            {
                request.Definition.CedarJson = requestDefinition_definition_CedarJson;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
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
        
        private Amazon.VerifiedPermissions.Model.PutSchemaResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.PutSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "PutSchema");
            try
            {
                #if DESKTOP
                return client.PutSchema(request);
                #elif CORECLR
                return client.PutSchemaAsync(request).GetAwaiter().GetResult();
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
            public System.String Definition_CedarJson { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.PutSchemaResponse, WriteAVPSchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
