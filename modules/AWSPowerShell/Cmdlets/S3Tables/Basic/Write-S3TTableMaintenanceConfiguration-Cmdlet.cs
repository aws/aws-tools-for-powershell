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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Creates a new maintenance configuration or replaces an existing maintenance configuration
    /// for a table. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-maintenance.html">S3
    /// Tables maintenance</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:PutTableMaintenanceConfiguration</c> permission to use
    /// this operation. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Write", "S3TTableMaintenanceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Tables PutTableMaintenanceConfiguration API operation.", Operation = new[] {"PutTableMaintenanceConfiguration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.PutTableMaintenanceConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3Tables.Model.PutTableMaintenanceConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Tables.Model.PutTableMaintenanceConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3TTableMaintenanceConfigurationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IcebergSnapshotManagement_MaxSnapshotAgeHour
        /// <summary>
        /// <para>
        /// <para>The maximum age of a snapshot before it can be expired.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Value_Settings_IcebergSnapshotManagement_MaxSnapshotAgeHours")]
        public System.Int32? IcebergSnapshotManagement_MaxSnapshotAgeHour { get; set; }
        #endregion
        
        #region Parameter IcebergSnapshotManagement_MinSnapshotsToKeep
        /// <summary>
        /// <para>
        /// <para>The minimum number of snapshots to keep.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Value_Settings_IcebergSnapshotManagement_MinSnapshotsToKeep")]
        public System.Int32? IcebergSnapshotManagement_MinSnapshotsToKeep { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the maintenance configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the table.</para>
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
        public System.String Namespace { get; set; }
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
        
        #region Parameter IcebergCompaction_Strategy
        /// <summary>
        /// <para>
        /// <para>The compaction strategy to use for the table. This determines how files are selected
        /// and combined during compaction operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Value_Settings_IcebergCompaction_Strategy")]
        [AWSConstantClassSource("Amazon.S3Tables.IcebergCompactionStrategy")]
        public Amazon.S3Tables.IcebergCompactionStrategy IcebergCompaction_Strategy { get; set; }
        #endregion
        
        #region Parameter TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table associated with the maintenance configuration.</para>
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
        
        #region Parameter IcebergCompaction_TargetFileSizeMB
        /// <summary>
        /// <para>
        /// <para>The target file size for the table in MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Value_Settings_IcebergCompaction_TargetFileSizeMB")]
        public System.Int32? IcebergCompaction_TargetFileSizeMB { get; set; }
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
        [AWSConstantClassSource("Amazon.S3Tables.TableMaintenanceType")]
        public Amazon.S3Tables.TableMaintenanceType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.PutTableMaintenanceConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3TTableMaintenanceConfiguration (PutTableMaintenanceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.PutTableMaintenanceConfigurationResponse, WriteS3TTableMaintenanceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.IcebergCompaction_Strategy = this.IcebergCompaction_Strategy;
            context.IcebergCompaction_TargetFileSizeMB = this.IcebergCompaction_TargetFileSizeMB;
            context.IcebergSnapshotManagement_MaxSnapshotAgeHour = this.IcebergSnapshotManagement_MaxSnapshotAgeHour;
            context.IcebergSnapshotManagement_MinSnapshotsToKeep = this.IcebergSnapshotManagement_MinSnapshotsToKeep;
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
            var request = new Amazon.S3Tables.Model.PutTableMaintenanceConfigurationRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.TableBucketARN != null)
            {
                request.TableBucketARN = cmdletContext.TableBucketARN;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
             // populate Value
            request.Value = new Amazon.S3Tables.Model.TableMaintenanceConfigurationValue();
            Amazon.S3Tables.MaintenanceStatus requestValue_value_Status = null;
            if (cmdletContext.Value_Status != null)
            {
                requestValue_value_Status = cmdletContext.Value_Status;
            }
            if (requestValue_value_Status != null)
            {
                request.Value.Status = requestValue_value_Status;
            }
            Amazon.S3Tables.Model.TableMaintenanceSettings requestValue_value_Settings = null;
            
             // populate Settings
            var requestValue_value_SettingsIsNull = true;
            requestValue_value_Settings = new Amazon.S3Tables.Model.TableMaintenanceSettings();
            Amazon.S3Tables.Model.IcebergCompactionSettings requestValue_value_Settings_value_Settings_IcebergCompaction = null;
            
             // populate IcebergCompaction
            var requestValue_value_Settings_value_Settings_IcebergCompactionIsNull = true;
            requestValue_value_Settings_value_Settings_IcebergCompaction = new Amazon.S3Tables.Model.IcebergCompactionSettings();
            Amazon.S3Tables.IcebergCompactionStrategy requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_Strategy = null;
            if (cmdletContext.IcebergCompaction_Strategy != null)
            {
                requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_Strategy = cmdletContext.IcebergCompaction_Strategy;
            }
            if (requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_Strategy != null)
            {
                requestValue_value_Settings_value_Settings_IcebergCompaction.Strategy = requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_Strategy;
                requestValue_value_Settings_value_Settings_IcebergCompactionIsNull = false;
            }
            System.Int32? requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_TargetFileSizeMB = null;
            if (cmdletContext.IcebergCompaction_TargetFileSizeMB != null)
            {
                requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_TargetFileSizeMB = cmdletContext.IcebergCompaction_TargetFileSizeMB.Value;
            }
            if (requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_TargetFileSizeMB != null)
            {
                requestValue_value_Settings_value_Settings_IcebergCompaction.TargetFileSizeMB = requestValue_value_Settings_value_Settings_IcebergCompaction_icebergCompaction_TargetFileSizeMB.Value;
                requestValue_value_Settings_value_Settings_IcebergCompactionIsNull = false;
            }
             // determine if requestValue_value_Settings_value_Settings_IcebergCompaction should be set to null
            if (requestValue_value_Settings_value_Settings_IcebergCompactionIsNull)
            {
                requestValue_value_Settings_value_Settings_IcebergCompaction = null;
            }
            if (requestValue_value_Settings_value_Settings_IcebergCompaction != null)
            {
                requestValue_value_Settings.IcebergCompaction = requestValue_value_Settings_value_Settings_IcebergCompaction;
                requestValue_value_SettingsIsNull = false;
            }
            Amazon.S3Tables.Model.IcebergSnapshotManagementSettings requestValue_value_Settings_value_Settings_IcebergSnapshotManagement = null;
            
             // populate IcebergSnapshotManagement
            var requestValue_value_Settings_value_Settings_IcebergSnapshotManagementIsNull = true;
            requestValue_value_Settings_value_Settings_IcebergSnapshotManagement = new Amazon.S3Tables.Model.IcebergSnapshotManagementSettings();
            System.Int32? requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MaxSnapshotAgeHour = null;
            if (cmdletContext.IcebergSnapshotManagement_MaxSnapshotAgeHour != null)
            {
                requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MaxSnapshotAgeHour = cmdletContext.IcebergSnapshotManagement_MaxSnapshotAgeHour.Value;
            }
            if (requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MaxSnapshotAgeHour != null)
            {
                requestValue_value_Settings_value_Settings_IcebergSnapshotManagement.MaxSnapshotAgeHours = requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MaxSnapshotAgeHour.Value;
                requestValue_value_Settings_value_Settings_IcebergSnapshotManagementIsNull = false;
            }
            System.Int32? requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MinSnapshotsToKeep = null;
            if (cmdletContext.IcebergSnapshotManagement_MinSnapshotsToKeep != null)
            {
                requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MinSnapshotsToKeep = cmdletContext.IcebergSnapshotManagement_MinSnapshotsToKeep.Value;
            }
            if (requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MinSnapshotsToKeep != null)
            {
                requestValue_value_Settings_value_Settings_IcebergSnapshotManagement.MinSnapshotsToKeep = requestValue_value_Settings_value_Settings_IcebergSnapshotManagement_icebergSnapshotManagement_MinSnapshotsToKeep.Value;
                requestValue_value_Settings_value_Settings_IcebergSnapshotManagementIsNull = false;
            }
             // determine if requestValue_value_Settings_value_Settings_IcebergSnapshotManagement should be set to null
            if (requestValue_value_Settings_value_Settings_IcebergSnapshotManagementIsNull)
            {
                requestValue_value_Settings_value_Settings_IcebergSnapshotManagement = null;
            }
            if (requestValue_value_Settings_value_Settings_IcebergSnapshotManagement != null)
            {
                requestValue_value_Settings.IcebergSnapshotManagement = requestValue_value_Settings_value_Settings_IcebergSnapshotManagement;
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
        
        private Amazon.S3Tables.Model.PutTableMaintenanceConfigurationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.PutTableMaintenanceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "PutTableMaintenanceConfiguration");
            try
            {
                #if DESKTOP
                return client.PutTableMaintenanceConfiguration(request);
                #elif CORECLR
                return client.PutTableMaintenanceConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String Namespace { get; set; }
            public System.String TableBucketARN { get; set; }
            public Amazon.S3Tables.TableMaintenanceType Type { get; set; }
            public Amazon.S3Tables.IcebergCompactionStrategy IcebergCompaction_Strategy { get; set; }
            public System.Int32? IcebergCompaction_TargetFileSizeMB { get; set; }
            public System.Int32? IcebergSnapshotManagement_MaxSnapshotAgeHour { get; set; }
            public System.Int32? IcebergSnapshotManagement_MinSnapshotsToKeep { get; set; }
            public Amazon.S3Tables.MaintenanceStatus Value_Status { get; set; }
            public System.Func<Amazon.S3Tables.Model.PutTableMaintenanceConfigurationResponse, WriteS3TTableMaintenanceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
