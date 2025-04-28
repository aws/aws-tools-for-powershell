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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Creates a new maintenance configuration or replaces an existing maintenance configuration
    /// for a table bucket. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-table-buckets-maintenance.html">Amazon
    /// S3 table bucket maintenance</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:PutTableBucketMaintenanceConfiguration</c> permission
    /// to use this operation. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Write", "S3TTableBucketMaintenanceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Tables PutTableBucketMaintenanceConfiguration API operation.", Operation = new[] {"PutTableBucketMaintenanceConfiguration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3TTableBucketMaintenanceConfigurationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IcebergUnreferencedFileRemoval_NonCurrentDay
        /// <summary>
        /// <para>
        /// <para>The number of days an object has to be non-current before it is deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Value_Settings_IcebergUnreferencedFileRemoval_NonCurrentDays")]
        public System.Int32? IcebergUnreferencedFileRemoval_NonCurrentDay { get; set; }
        #endregion
        
        #region Parameter Value_Status
        /// <summary>
        /// <para>
        /// <para>The status of the maintenance configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.MaintenanceStatus")]
        public Amazon.S3Tables.MaintenanceStatus Value_Status { get; set; }
        #endregion
        
        #region Parameter TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table bucket associated with the maintenance
        /// configuration.</para>
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
        public System.String TableBucketARN { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the maintenance configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Tables.TableBucketMaintenanceType")]
        public Amazon.S3Tables.TableBucketMaintenanceType Type { get; set; }
        #endregion
        
        #region Parameter IcebergUnreferencedFileRemoval_UnreferencedDay
        /// <summary>
        /// <para>
        /// <para>The number of days an object has to be unreferenced before it is marked as non-current.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Value_Settings_IcebergUnreferencedFileRemoval_UnreferencedDays")]
        public System.Int32? IcebergUnreferencedFileRemoval_UnreferencedDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableBucketARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3TTableBucketMaintenanceConfiguration (PutTableBucketMaintenanceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationResponse, WriteS3TTableBucketMaintenanceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TableBucketARN = this.TableBucketARN;
            #if MODULAR
            if (this.TableBucketARN == null && ParameterWasBound(nameof(this.TableBucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TableBucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IcebergUnreferencedFileRemoval_NonCurrentDay = this.IcebergUnreferencedFileRemoval_NonCurrentDay;
            context.IcebergUnreferencedFileRemoval_UnreferencedDay = this.IcebergUnreferencedFileRemoval_UnreferencedDay;
            context.Value_Status = this.Value_Status;
            
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
            var request = new Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationRequest();
            
            if (cmdletContext.TableBucketARN != null)
            {
                request.TableBucketARN = cmdletContext.TableBucketARN;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
             // populate Value
            var requestValueIsNull = true;
            request.Value = new Amazon.S3Tables.Model.TableBucketMaintenanceConfigurationValue();
            Amazon.S3Tables.MaintenanceStatus requestValue_value_Status = null;
            if (cmdletContext.Value_Status != null)
            {
                requestValue_value_Status = cmdletContext.Value_Status;
            }
            if (requestValue_value_Status != null)
            {
                request.Value.Status = requestValue_value_Status;
                requestValueIsNull = false;
            }
            Amazon.S3Tables.Model.TableBucketMaintenanceSettings requestValue_value_Settings = null;
            
             // populate Settings
            var requestValue_value_SettingsIsNull = true;
            requestValue_value_Settings = new Amazon.S3Tables.Model.TableBucketMaintenanceSettings();
            Amazon.S3Tables.Model.IcebergUnreferencedFileRemovalSettings requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval = null;
            
             // populate IcebergUnreferencedFileRemoval
            var requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemovalIsNull = true;
            requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval = new Amazon.S3Tables.Model.IcebergUnreferencedFileRemovalSettings();
            System.Int32? requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_NonCurrentDay = null;
            if (cmdletContext.IcebergUnreferencedFileRemoval_NonCurrentDay != null)
            {
                requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_NonCurrentDay = cmdletContext.IcebergUnreferencedFileRemoval_NonCurrentDay.Value;
            }
            if (requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_NonCurrentDay != null)
            {
                requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval.NonCurrentDays = requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_NonCurrentDay.Value;
                requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemovalIsNull = false;
            }
            System.Int32? requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_UnreferencedDay = null;
            if (cmdletContext.IcebergUnreferencedFileRemoval_UnreferencedDay != null)
            {
                requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_UnreferencedDay = cmdletContext.IcebergUnreferencedFileRemoval_UnreferencedDay.Value;
            }
            if (requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_UnreferencedDay != null)
            {
                requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval.UnreferencedDays = requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval_icebergUnreferencedFileRemoval_UnreferencedDay.Value;
                requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemovalIsNull = false;
            }
             // determine if requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval should be set to null
            if (requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemovalIsNull)
            {
                requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval = null;
            }
            if (requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval != null)
            {
                requestValue_value_Settings.IcebergUnreferencedFileRemoval = requestValue_value_Settings_value_Settings_IcebergUnreferencedFileRemoval;
                requestValue_value_SettingsIsNull = false;
            }
             // determine if requestValue_value_Settings should be set to null
            if (requestValue_value_SettingsIsNull)
            {
                requestValue_value_Settings = null;
            }
            if (requestValue_value_Settings != null)
            {
                request.Value.Settings = requestValue_value_Settings;
                requestValueIsNull = false;
            }
             // determine if request.Value should be set to null
            if (requestValueIsNull)
            {
                request.Value = null;
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
        
        private Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "PutTableBucketMaintenanceConfiguration");
            try
            {
                return client.PutTableBucketMaintenanceConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TableBucketARN { get; set; }
            public Amazon.S3Tables.TableBucketMaintenanceType Type { get; set; }
            public System.Int32? IcebergUnreferencedFileRemoval_NonCurrentDay { get; set; }
            public System.Int32? IcebergUnreferencedFileRemoval_UnreferencedDay { get; set; }
            public Amazon.S3Tables.MaintenanceStatus Value_Status { get; set; }
            public System.Func<Amazon.S3Tables.Model.PutTableBucketMaintenanceConfigurationResponse, WriteS3TTableBucketMaintenanceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
