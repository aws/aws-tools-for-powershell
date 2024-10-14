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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Updates a storage profile.
    /// </summary>
    [Cmdlet("Update", "ADCStorageProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWSDeadlineCloud UpdateStorageProfile API operation.", Operation = new[] {"UpdateStorageProfile"}, SelectReturnType = typeof(Amazon.Deadline.Model.UpdateStorageProfileResponse))]
    [AWSCmdletOutput("None or Amazon.Deadline.Model.UpdateStorageProfileResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Deadline.Model.UpdateStorageProfileResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateADCStorageProfileCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the storage profile to update.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID to update.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter FileSystemLocationsToAdd
        /// <summary>
        /// <para>
        /// <para>The file system location names to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Deadline.Model.FileSystemLocation[] FileSystemLocationsToAdd { get; set; }
        #endregion
        
        #region Parameter FileSystemLocationsToRemove
        /// <summary>
        /// <para>
        /// <para>The file system location names to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Deadline.Model.FileSystemLocation[] FileSystemLocationsToRemove { get; set; }
        #endregion
        
        #region Parameter OsFamily
        /// <summary>
        /// <para>
        /// <para>The OS system to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.StorageProfileOperatingSystemFamily")]
        public Amazon.Deadline.StorageProfileOperatingSystemFamily OsFamily { get; set; }
        #endregion
        
        #region Parameter StorageProfileId
        /// <summary>
        /// <para>
        /// <para>The storage profile ID to update.</para>
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
        public System.String StorageProfileId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique token which the server uses to recognize retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.UpdateStorageProfileResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ADCStorageProfile (UpdateStorageProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.UpdateStorageProfileResponse, UpdateADCStorageProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DisplayName = this.DisplayName;
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FileSystemLocationsToAdd != null)
            {
                context.FileSystemLocationsToAdd = new List<Amazon.Deadline.Model.FileSystemLocation>(this.FileSystemLocationsToAdd);
            }
            if (this.FileSystemLocationsToRemove != null)
            {
                context.FileSystemLocationsToRemove = new List<Amazon.Deadline.Model.FileSystemLocation>(this.FileSystemLocationsToRemove);
            }
            context.OsFamily = this.OsFamily;
            context.StorageProfileId = this.StorageProfileId;
            #if MODULAR
            if (this.StorageProfileId == null && ParameterWasBound(nameof(this.StorageProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Deadline.Model.UpdateStorageProfileRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            if (cmdletContext.FileSystemLocationsToAdd != null)
            {
                request.FileSystemLocationsToAdd = cmdletContext.FileSystemLocationsToAdd;
            }
            if (cmdletContext.FileSystemLocationsToRemove != null)
            {
                request.FileSystemLocationsToRemove = cmdletContext.FileSystemLocationsToRemove;
            }
            if (cmdletContext.OsFamily != null)
            {
                request.OsFamily = cmdletContext.OsFamily;
            }
            if (cmdletContext.StorageProfileId != null)
            {
                request.StorageProfileId = cmdletContext.StorageProfileId;
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
        
        private Amazon.Deadline.Model.UpdateStorageProfileResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.UpdateStorageProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "UpdateStorageProfile");
            try
            {
                #if DESKTOP
                return client.UpdateStorageProfile(request);
                #elif CORECLR
                return client.UpdateStorageProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FarmId { get; set; }
            public List<Amazon.Deadline.Model.FileSystemLocation> FileSystemLocationsToAdd { get; set; }
            public List<Amazon.Deadline.Model.FileSystemLocation> FileSystemLocationsToRemove { get; set; }
            public Amazon.Deadline.StorageProfileOperatingSystemFamily OsFamily { get; set; }
            public System.String StorageProfileId { get; set; }
            public System.Func<Amazon.Deadline.Model.UpdateStorageProfileResponse, UpdateADCStorageProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
