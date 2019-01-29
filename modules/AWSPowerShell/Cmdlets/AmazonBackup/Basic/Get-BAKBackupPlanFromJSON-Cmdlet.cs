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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns a valid JSON document specifying a backup plan or an error.
    /// </summary>
    [Cmdlet("Get", "BAKBackupPlanFromJSON")]
    [OutputType("Amazon.Backup.Model.BackupPlan")]
    [AWSCmdlet("Calls the Amazon Backup GetBackupPlanFromJSON API operation.", Operation = new[] {"GetBackupPlanFromJSON"})]
    [AWSCmdletOutput("Amazon.Backup.Model.BackupPlan",
        "This cmdlet returns a BackupPlan object.",
        "The service call response (type Amazon.Backup.Model.GetBackupPlanFromJSONResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetBAKBackupPlanFromJSONCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter BackupPlanTemplateJson
        /// <summary>
        /// <para>
        /// <para>A customer-supplied backup plan document in JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String BackupPlanTemplateJson { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.BackupPlanTemplateJson = this.BackupPlanTemplateJson;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BackupPlan;
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
        
        private Amazon.Backup.Model.GetBackupPlanFromJSONResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.GetBackupPlanFromJSONRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Backup", "GetBackupPlanFromJSON");
            try
            {
                #if DESKTOP
                return client.GetBackupPlanFromJSON(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetBackupPlanFromJSONAsync(request);
                return task.Result;
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
        }
        
    }
}
