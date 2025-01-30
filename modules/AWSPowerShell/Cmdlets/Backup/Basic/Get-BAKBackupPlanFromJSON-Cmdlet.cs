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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns a valid JSON document specifying a backup plan or an error.
    /// </summary>
    [Cmdlet("Get", "BAKBackupPlanFromJSON")]
    [OutputType("Amazon.Backup.Model.BackupPlan")]
    [AWSCmdlet("Calls the AWS Backup GetBackupPlanFromJSON API operation.", Operation = new[] {"GetBackupPlanFromJSON"}, SelectReturnType = typeof(Amazon.Backup.Model.GetBackupPlanFromJSONResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.BackupPlan or Amazon.Backup.Model.GetBackupPlanFromJSONResponse",
        "This cmdlet returns an Amazon.Backup.Model.BackupPlan object.",
        "The service call response (type Amazon.Backup.Model.GetBackupPlanFromJSONResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAKBackupPlanFromJSONCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupPlanTemplateJson
        /// <summary>
        /// <para>
        /// <para>A customer-supplied backup plan document in JSON format.</para>
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
        public System.String BackupPlanTemplateJson { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackupPlan'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.GetBackupPlanFromJSONResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.GetBackupPlanFromJSONResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackupPlan";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BackupPlanTemplateJson parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BackupPlanTemplateJson' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BackupPlanTemplateJson' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.GetBackupPlanFromJSONResponse, GetBAKBackupPlanFromJSONCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BackupPlanTemplateJson;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupPlanTemplateJson = this.BackupPlanTemplateJson;
            #if MODULAR
            if (this.BackupPlanTemplateJson == null && ParameterWasBound(nameof(this.BackupPlanTemplateJson)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupPlanTemplateJson which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.GetBackupPlanFromJSONRequest();
            
            if (cmdletContext.BackupPlanTemplateJson != null)
            {
                request.BackupPlanTemplateJson = cmdletContext.BackupPlanTemplateJson;
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
        
        private Amazon.Backup.Model.GetBackupPlanFromJSONResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.GetBackupPlanFromJSONRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "GetBackupPlanFromJSON");
            try
            {
                #if DESKTOP
                return client.GetBackupPlanFromJSON(request);
                #elif CORECLR
                return client.GetBackupPlanFromJSONAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupPlanTemplateJson { get; set; }
            public System.Func<Amazon.Backup.Model.GetBackupPlanFromJSONResponse, GetBAKBackupPlanFromJSONCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackupPlan;
        }
        
    }
}
