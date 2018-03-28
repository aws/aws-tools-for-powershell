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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// <code>UpdateContinuousBackups</code> enables or disables point in time recovery for
    /// the specified table. A successful <code>UpdateContinuousBackups</code> call returns
    /// the current <code>ContinuousBackupsDescription</code>. Continuous backups are <code>ENABLED</code>
    /// on all tables at table creation. If point in time recovery is enabled, <code>PointInTimeRecoveryStatus</code>
    /// will be set to ENABLED.
    /// 
    ///  
    /// <para>
    ///  Once continuous backups and point in time recovery are enabled, you can restore to
    /// any point in time within <code>EarliestRestorableDateTime</code> and <code>LatestRestorableDateTime</code>.
    /// 
    /// </para><para><code>LatestRestorableDateTime</code> is typically 5 minutes before the current time.
    /// You can restore your table to any point in time during the last 35 days with a 1-minute
    /// granularity. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DDBContinuousBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateContinuousBackups API operation.", Operation = new[] {"UpdateContinuousBackups"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription",
        "This cmdlet returns a ContinuousBackupsDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDDBContinuousBackupCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether point in time recovery is enabled (true) or disabled (false) on
        /// the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TableName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBContinuousBackup (UpdateContinuousBackups)"))
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
            
            if (ParameterWasBound("PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled"))
                context.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled = this.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled;
            context.TableName = this.TableName;
            
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
            var request = new Amazon.DynamoDBv2.Model.UpdateContinuousBackupsRequest();
            
            
             // populate PointInTimeRecoverySpecification
            bool requestPointInTimeRecoverySpecificationIsNull = true;
            request.PointInTimeRecoverySpecification = new Amazon.DynamoDBv2.Model.PointInTimeRecoverySpecification();
            System.Boolean? requestPointInTimeRecoverySpecification_pointInTimeRecoverySpecification_PointInTimeRecoveryEnabled = null;
            if (cmdletContext.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled != null)
            {
                requestPointInTimeRecoverySpecification_pointInTimeRecoverySpecification_PointInTimeRecoveryEnabled = cmdletContext.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled.Value;
            }
            if (requestPointInTimeRecoverySpecification_pointInTimeRecoverySpecification_PointInTimeRecoveryEnabled != null)
            {
                request.PointInTimeRecoverySpecification.PointInTimeRecoveryEnabled = requestPointInTimeRecoverySpecification_pointInTimeRecoverySpecification_PointInTimeRecoveryEnabled.Value;
                requestPointInTimeRecoverySpecificationIsNull = false;
            }
             // determine if request.PointInTimeRecoverySpecification should be set to null
            if (requestPointInTimeRecoverySpecificationIsNull)
            {
                request.PointInTimeRecoverySpecification = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ContinuousBackupsDescription;
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
        
        private Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateContinuousBackupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateContinuousBackups");
            try
            {
                #if DESKTOP
                return client.UpdateContinuousBackups(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateContinuousBackupsAsync(request);
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
            public System.Boolean? PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled { get; set; }
            public System.String TableName { get; set; }
        }
        
    }
}
