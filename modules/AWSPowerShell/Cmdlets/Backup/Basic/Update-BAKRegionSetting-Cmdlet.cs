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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Updates the current service opt-in settings for the Region. If service-opt-in is enabled
    /// for a service, Backup tries to protect that service's resources in this Region, when
    /// the resource is included in an on-demand backup or scheduled backup plan. Otherwise,
    /// Backup does not try to protect that service's resources in this Region. Use the <code>DescribeRegionSettings</code>
    /// API to determine the resource types that are supported.
    /// </summary>
    [Cmdlet("Update", "BAKRegionSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Backup UpdateRegionSettings API operation.", Operation = new[] {"UpdateRegionSettings"}, SelectReturnType = typeof(Amazon.Backup.Model.UpdateRegionSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.Backup.Model.UpdateRegionSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Backup.Model.UpdateRegionSettingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBAKRegionSettingCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceTypeManagementPreference
        /// <summary>
        /// <para>
        /// <para>Enables or disables full Backup management of backups for a resource type. To enable
        /// full Backup management for DynamoDB along with <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/advanced-ddb-backup.html">
        /// Backup's advanced DynamoDB backup features</a>, follow the procedure to <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/advanced-ddb-backup.html#advanced-ddb-backup-enable-cli">
        /// enable advanced DynamoDB backup programmatically</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ResourceTypeManagementPreference { get; set; }
        #endregion
        
        #region Parameter ResourceTypeOptInPreference
        /// <summary>
        /// <para>
        /// <para>Updates the list of services along with the opt-in preferences for the Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ResourceTypeOptInPreference { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.UpdateRegionSettingsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceTypeOptInPreference), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKRegionSetting (UpdateRegionSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.UpdateRegionSettingsResponse, UpdateBAKRegionSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ResourceTypeManagementPreference != null)
            {
                context.ResourceTypeManagementPreference = new Dictionary<System.String, System.Boolean>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResourceTypeManagementPreference.Keys)
                {
                    context.ResourceTypeManagementPreference.Add((String)hashKey, (Boolean)(this.ResourceTypeManagementPreference[hashKey]));
                }
            }
            if (this.ResourceTypeOptInPreference != null)
            {
                context.ResourceTypeOptInPreference = new Dictionary<System.String, System.Boolean>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResourceTypeOptInPreference.Keys)
                {
                    context.ResourceTypeOptInPreference.Add((String)hashKey, (Boolean)(this.ResourceTypeOptInPreference[hashKey]));
                }
            }
            
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
            var request = new Amazon.Backup.Model.UpdateRegionSettingsRequest();
            
            if (cmdletContext.ResourceTypeManagementPreference != null)
            {
                request.ResourceTypeManagementPreference = cmdletContext.ResourceTypeManagementPreference;
            }
            if (cmdletContext.ResourceTypeOptInPreference != null)
            {
                request.ResourceTypeOptInPreference = cmdletContext.ResourceTypeOptInPreference;
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
        
        private Amazon.Backup.Model.UpdateRegionSettingsResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateRegionSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "UpdateRegionSettings");
            try
            {
                #if DESKTOP
                return client.UpdateRegionSettings(request);
                #elif CORECLR
                return client.UpdateRegionSettingsAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.Boolean> ResourceTypeManagementPreference { get; set; }
            public Dictionary<System.String, System.Boolean> ResourceTypeOptInPreference { get; set; }
            public System.Func<Amazon.Backup.Model.UpdateRegionSettingsResponse, UpdateBAKRegionSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
