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
using Amazon.Schemas;
using Amazon.Schemas.Model;

namespace Amazon.PowerShell.Cmdlets.SCHM
{
    /// <summary>
    /// Delete the schema version definition
    /// </summary>
    [Cmdlet("Remove", "SCHMSchemaVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon EventBridge Schema Registry DeleteSchemaVersion API operation.", Operation = new[] {"DeleteSchemaVersion"}, SelectReturnType = typeof(Amazon.Schemas.Model.DeleteSchemaVersionResponse))]
    [AWSCmdletOutput("None or Amazon.Schemas.Model.DeleteSchemaVersionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Schemas.Model.DeleteSchemaVersionResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSCHMSchemaVersionCmdlet : AmazonSchemasClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter SchemaVersion
        /// <summary>
        /// <para>
        /// The version number of the schema
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
        public System.String SchemaVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Schemas.Model.DeleteSchemaVersionResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SchemaName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SCHMSchemaVersion (DeleteSchemaVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Schemas.Model.DeleteSchemaVersionResponse, RemoveSCHMSchemaVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.SchemaVersion = this.SchemaVersion;
            #if MODULAR
            if (this.SchemaVersion == null && ParameterWasBound(nameof(this.SchemaVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Schemas.Model.DeleteSchemaVersionRequest();
            
            if (cmdletContext.RegistryName != null)
            {
                request.RegistryName = cmdletContext.RegistryName;
            }
            if (cmdletContext.SchemaName != null)
            {
                request.SchemaName = cmdletContext.SchemaName;
            }
            if (cmdletContext.SchemaVersion != null)
            {
                request.SchemaVersion = cmdletContext.SchemaVersion;
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
        
        private Amazon.Schemas.Model.DeleteSchemaVersionResponse CallAWSServiceOperation(IAmazonSchemas client, Amazon.Schemas.Model.DeleteSchemaVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge Schema Registry", "DeleteSchemaVersion");
            try
            {
                return client.DeleteSchemaVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RegistryName { get; set; }
            public System.String SchemaName { get; set; }
            public System.String SchemaVersion { get; set; }
            public System.Func<Amazon.Schemas.Model.DeleteSchemaVersionResponse, RemoveSCHMSchemaVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
