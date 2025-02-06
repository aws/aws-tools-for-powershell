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
using Amazon.Schemas;
using Amazon.Schemas.Model;

namespace Amazon.PowerShell.Cmdlets.SCHM
{
    /// <summary>
    /// Updates the schema definition
    /// 
    ///  <note><para>
    /// Inactive schemas will be deleted after two years.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SCHMSchema", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Schemas.Model.UpdateSchemaResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge Schema Registry UpdateSchema API operation.", Operation = new[] {"UpdateSchema"}, SelectReturnType = typeof(Amazon.Schemas.Model.UpdateSchemaResponse))]
    [AWSCmdletOutput("Amazon.Schemas.Model.UpdateSchemaResponse",
        "This cmdlet returns an Amazon.Schemas.Model.UpdateSchemaResponse object containing multiple properties."
    )]
    public partial class UpdateSCHMSchemaCmdlet : AmazonSchemasClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientTokenId
        /// <summary>
        /// <para>
        /// <para>The ID of the client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientTokenId { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The source of the schema definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RegistryName
        /// <summary>
        /// <para>
        /// <para>The name of the registry.</para>
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
        public System.String RegistryName { get; set; }
        #endregion
        
        #region Parameter SchemaName
        /// <summary>
        /// <para>
        /// <para>The name of the schema.</para>
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
        public System.String SchemaName { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The schema type for the events schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Schemas.Type")]
        public Amazon.Schemas.Type Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Schemas.Model.UpdateSchemaResponse).
        /// Specifying the name of a property of type Amazon.Schemas.Model.UpdateSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SchemaName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCHMSchema (UpdateSchema)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Schemas.Model.UpdateSchemaResponse, UpdateSCHMSchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientTokenId = this.ClientTokenId;
            context.Content = this.Content;
            context.Description = this.Description;
            context.RegistryName = this.RegistryName;
            #if MODULAR
            if (this.RegistryName == null && ParameterWasBound(nameof(this.RegistryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchemaName = this.SchemaName;
            #if MODULAR
            if (this.SchemaName == null && ParameterWasBound(nameof(this.SchemaName)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            
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
            var request = new Amazon.Schemas.Model.UpdateSchemaRequest();
            
            if (cmdletContext.ClientTokenId != null)
            {
                request.ClientTokenId = cmdletContext.ClientTokenId;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RegistryName != null)
            {
                request.RegistryName = cmdletContext.RegistryName;
            }
            if (cmdletContext.SchemaName != null)
            {
                request.SchemaName = cmdletContext.SchemaName;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Schemas.Model.UpdateSchemaResponse CallAWSServiceOperation(IAmazonSchemas client, Amazon.Schemas.Model.UpdateSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge Schema Registry", "UpdateSchema");
            try
            {
                #if DESKTOP
                return client.UpdateSchema(request);
                #elif CORECLR
                return client.UpdateSchemaAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientTokenId { get; set; }
            public System.String Content { get; set; }
            public System.String Description { get; set; }
            public System.String RegistryName { get; set; }
            public System.String SchemaName { get; set; }
            public Amazon.Schemas.Type Type { get; set; }
            public System.Func<Amazon.Schemas.Model.UpdateSchemaResponse, UpdateSCHMSchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
