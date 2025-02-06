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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Deregisters a package version.
    /// </summary>
    [Cmdlet("Unregister", "PANPackageVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Panorama DeregisterPackageVersion API operation.", Operation = new[] {"DeregisterPackageVersion"}, SelectReturnType = typeof(Amazon.Panorama.Model.DeregisterPackageVersionResponse))]
    [AWSCmdletOutput("None or Amazon.Panorama.Model.DeregisterPackageVersionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Panorama.Model.DeregisterPackageVersionResponse) be returned by specifying '-Select *'."
    )]
    public partial class UnregisterPANPackageVersionCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>An owner account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter PackageId
        /// <summary>
        /// <para>
        /// <para>A package ID.</para>
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
        public System.String PackageId { get; set; }
        #endregion
        
        #region Parameter PackageVersion
        /// <summary>
        /// <para>
        /// <para>A package version.</para>
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
        public System.String PackageVersion { get; set; }
        #endregion
        
        #region Parameter PatchVersion
        /// <summary>
        /// <para>
        /// <para>A patch version.</para>
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
        public System.String PatchVersion { get; set; }
        #endregion
        
        #region Parameter UpdatedLatestPatchVersion
        /// <summary>
        /// <para>
        /// <para>If the version was marked latest, the new version to maker as latest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedLatestPatchVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.DeregisterPackageVersionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PackageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-PANPackageVersion (DeregisterPackageVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.DeregisterPackageVersionResponse, UnregisterPANPackageVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OwnerAccount = this.OwnerAccount;
            context.PackageId = this.PackageId;
            #if MODULAR
            if (this.PackageId == null && ParameterWasBound(nameof(this.PackageId)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageVersion = this.PackageVersion;
            #if MODULAR
            if (this.PackageVersion == null && ParameterWasBound(nameof(this.PackageVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PatchVersion = this.PatchVersion;
            #if MODULAR
            if (this.PatchVersion == null && ParameterWasBound(nameof(this.PatchVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter PatchVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdatedLatestPatchVersion = this.UpdatedLatestPatchVersion;
            
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
            var request = new Amazon.Panorama.Model.DeregisterPackageVersionRequest();
            
            if (cmdletContext.OwnerAccount != null)
            {
                request.OwnerAccount = cmdletContext.OwnerAccount;
            }
            if (cmdletContext.PackageId != null)
            {
                request.PackageId = cmdletContext.PackageId;
            }
            if (cmdletContext.PackageVersion != null)
            {
                request.PackageVersion = cmdletContext.PackageVersion;
            }
            if (cmdletContext.PatchVersion != null)
            {
                request.PatchVersion = cmdletContext.PatchVersion;
            }
            if (cmdletContext.UpdatedLatestPatchVersion != null)
            {
                request.UpdatedLatestPatchVersion = cmdletContext.UpdatedLatestPatchVersion;
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
        
        private Amazon.Panorama.Model.DeregisterPackageVersionResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.DeregisterPackageVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "DeregisterPackageVersion");
            try
            {
                #if DESKTOP
                return client.DeregisterPackageVersion(request);
                #elif CORECLR
                return client.DeregisterPackageVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String OwnerAccount { get; set; }
            public System.String PackageId { get; set; }
            public System.String PackageVersion { get; set; }
            public System.String PatchVersion { get; set; }
            public System.String UpdatedLatestPatchVersion { get; set; }
            public System.Func<Amazon.Panorama.Model.DeregisterPackageVersionResponse, UnregisterPANPackageVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
