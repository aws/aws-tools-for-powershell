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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// This API call updates the landing zone. It starts an asynchronous operation that updates
    /// the landing zone based on the new landing zone version, or on the changed parameters
    /// specified in the updated manifest file.
    /// </summary>
    [Cmdlet("Update", "ACTLandingZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Control Tower UpdateLandingZone API operation.", Operation = new[] {"UpdateLandingZone"}, SelectReturnType = typeof(Amazon.ControlTower.Model.UpdateLandingZoneResponse))]
    [AWSCmdletOutput("System.String or Amazon.ControlTower.Model.UpdateLandingZoneResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ControlTower.Model.UpdateLandingZoneResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateACTLandingZoneCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LandingZoneIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the landing zone.</para>
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
        public System.String LandingZoneIdentifier { get; set; }
        #endregion
        
        #region Parameter Manifest
        /// <summary>
        /// <para>
        /// <para>The manifest file (JSON) is a text file that describes your Amazon Web Services resources.
        /// For an example, review <a href="https://docs.aws.amazon.com/controltower/latest/userguide/lz-api-launch">Launch
        /// your landing zone</a>. The example manifest file contains each of the available parameters.
        /// The schema for the landing zone's JSON manifest file is not published, by design.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Management.Automation.PSObject Manifest { get; set; }
        #endregion
        
        #region Parameter RemediationType
        /// <summary>
        /// <para>
        /// <para>Specifies the types of remediation actions to apply when updating the landing zone
        /// configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemediationTypes")]
        public System.String[] RemediationType { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The landing zone version, for example, 3.2.</para>
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
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationIdentifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.UpdateLandingZoneResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.UpdateLandingZoneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationIdentifier";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LandingZoneIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ACTLandingZone (UpdateLandingZone)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.UpdateLandingZoneResponse, UpdateACTLandingZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LandingZoneIdentifier = this.LandingZoneIdentifier;
            #if MODULAR
            if (this.LandingZoneIdentifier == null && ParameterWasBound(nameof(this.LandingZoneIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter LandingZoneIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Manifest = this.Manifest;
            #if MODULAR
            if (this.Manifest == null && ParameterWasBound(nameof(this.Manifest)))
            {
                WriteWarning("You are passing $null as a value for parameter Manifest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemediationType != null)
            {
                context.RemediationType = new List<System.String>(this.RemediationType);
            }
            context.Version = this.Version;
            #if MODULAR
            if (this.Version == null && ParameterWasBound(nameof(this.Version)))
            {
                WriteWarning("You are passing $null as a value for parameter Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ControlTower.Model.UpdateLandingZoneRequest();
            
            if (cmdletContext.LandingZoneIdentifier != null)
            {
                request.LandingZoneIdentifier = cmdletContext.LandingZoneIdentifier;
            }
            if (cmdletContext.Manifest != null)
            {
                request.Manifest = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Manifest);
            }
            if (cmdletContext.RemediationType != null)
            {
                request.RemediationTypes = cmdletContext.RemediationType;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.ControlTower.Model.UpdateLandingZoneResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.UpdateLandingZoneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "UpdateLandingZone");
            try
            {
                return client.UpdateLandingZoneAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LandingZoneIdentifier { get; set; }
            public System.Management.Automation.PSObject Manifest { get; set; }
            public List<System.String> RemediationType { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.ControlTower.Model.UpdateLandingZoneResponse, UpdateACTLandingZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationIdentifier;
        }
        
    }
}
