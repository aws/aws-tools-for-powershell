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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Deletes automated backups using the <c>DbClusterResourceId</c> value of the source
    /// DB cluster or the Amazon Resource Name (ARN) of the automated backups.
    /// </summary>
    [Cmdlet("Remove", "RDSDBClusterAutomatedBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.RDS.Model.DBClusterAutomatedBackup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DeleteDBClusterAutomatedBackup API operation.", Operation = new[] {"DeleteDBClusterAutomatedBackup"}, SelectReturnType = typeof(Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterAutomatedBackup or Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBClusterAutomatedBackup object.",
        "The service call response (type Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveRDSDBClusterAutomatedBackupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DbClusterResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier for the source DB cluster, which can't be changed and which is unique
        /// to an Amazon Web Services Region.</para>
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
        public System.String DbClusterResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterAutomatedBackup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterAutomatedBackup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DbClusterResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RDSDBClusterAutomatedBackup (DeleteDBClusterAutomatedBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse, RemoveRDSDBClusterAutomatedBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DbClusterResourceId = this.DbClusterResourceId;
            #if MODULAR
            if (this.DbClusterResourceId == null && ParameterWasBound(nameof(this.DbClusterResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DbClusterResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.DeleteDBClusterAutomatedBackupRequest();
            
            if (cmdletContext.DbClusterResourceId != null)
            {
                request.DbClusterResourceId = cmdletContext.DbClusterResourceId;
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
        
        private Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DeleteDBClusterAutomatedBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DeleteDBClusterAutomatedBackup");
            try
            {
                #if DESKTOP
                return client.DeleteDBClusterAutomatedBackup(request);
                #elif CORECLR
                return client.DeleteDBClusterAutomatedBackupAsync(request).GetAwaiter().GetResult();
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
            public System.String DbClusterResourceId { get; set; }
            public System.Func<Amazon.RDS.Model.DeleteDBClusterAutomatedBackupResponse, RemoveRDSDBClusterAutomatedBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterAutomatedBackup;
        }
        
    }
}
