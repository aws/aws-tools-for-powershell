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
    /// You can restore your table to any point in time during the last 35 days. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DDBContinuousBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateContinuousBackups API operation.", Operation = new[] {"UpdateContinuousBackups"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription or Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.ContinuousBackupsDescription object.",
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContinuousBackupsDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContinuousBackupsDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBContinuousBackup (UpdateContinuousBackups)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse, UpdateDDBContinuousBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled = this.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled;
            #if MODULAR
            if (this.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled == null && ParameterWasBound(nameof(this.PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter PointInTimeRecoverySpecification_PointInTimeRecoveryEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.UpdateContinuousBackupsRequest();
            
            
             // populate PointInTimeRecoverySpecification
            var requestPointInTimeRecoverySpecificationIsNull = true;
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
        
        private Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateContinuousBackupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateContinuousBackups");
            try
            {
                #if DESKTOP
                return client.UpdateContinuousBackups(request);
                #elif CORECLR
                return client.UpdateContinuousBackupsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.DynamoDBv2.Model.UpdateContinuousBackupsResponse, UpdateDDBContinuousBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContinuousBackupsDescription;
        }
        
    }
}
