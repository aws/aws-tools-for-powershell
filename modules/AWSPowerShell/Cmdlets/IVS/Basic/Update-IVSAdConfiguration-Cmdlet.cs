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
using Amazon.IVS;
using Amazon.IVS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Updates a specified ad configuration.
    /// </summary>
    [Cmdlet("Update", "IVSAdConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.AdConfiguration")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service UpdateAdConfiguration API operation.", Operation = new[] {"UpdateAdConfiguration"}, SelectReturnType = typeof(Amazon.IVS.Model.UpdateAdConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.AdConfiguration or Amazon.IVS.Model.UpdateAdConfigurationResponse",
        "This cmdlet returns an Amazon.IVS.Model.AdConfiguration object.",
        "The service call response (type Amazon.IVS.Model.UpdateAdConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIVSAdConfigurationCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the ad configuration to be updated.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter PostRollConfiguration_DurationSecond
        /// <summary>
        /// <para>
        /// <para>Duration of the post-roll ad break, in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostRollConfiguration_DurationSeconds")]
        public System.Int32? PostRollConfiguration_DurationSecond { get; set; }
        #endregion
        
        #region Parameter PostRollConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether the post-roll ad configuration is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PostRollConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter MediaTailorPlaybackConfiguration
        /// <summary>
        /// <para>
        /// <para>List of integration configurations with MediaTailor resources. The first item in the
        /// list is the default playback configuration used for the ad configuration. To select
        /// a different configuration per viewing session, see <a href="https://docs.aws.amazon.com/ivs/latest/LowLatencyUserGuide/private-channels-generate-tokens.html">Generate
        /// and Sign IVS Playback Tokens</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaTailorPlaybackConfigurations")]
        public Amazon.IVS.Model.MediaTailorPlaybackConfiguration[] MediaTailorPlaybackConfiguration { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Ad configuration name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AdConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.UpdateAdConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.UpdateAdConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AdConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IVSAdConfiguration (UpdateAdConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.UpdateAdConfigurationResponse, UpdateIVSAdConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MediaTailorPlaybackConfiguration != null)
            {
                context.MediaTailorPlaybackConfiguration = new List<Amazon.IVS.Model.MediaTailorPlaybackConfiguration>(this.MediaTailorPlaybackConfiguration);
            }
            context.Name = this.Name;
            context.PostRollConfiguration_DurationSecond = this.PostRollConfiguration_DurationSecond;
            context.PostRollConfiguration_Enabled = this.PostRollConfiguration_Enabled;
            
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
            var request = new Amazon.IVS.Model.UpdateAdConfigurationRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.MediaTailorPlaybackConfiguration != null)
            {
                request.MediaTailorPlaybackConfigurations = cmdletContext.MediaTailorPlaybackConfiguration;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PostRollConfiguration
            var requestPostRollConfigurationIsNull = true;
            request.PostRollConfiguration = new Amazon.IVS.Model.PostRollConfiguration();
            System.Int32? requestPostRollConfiguration_postRollConfiguration_DurationSecond = null;
            if (cmdletContext.PostRollConfiguration_DurationSecond != null)
            {
                requestPostRollConfiguration_postRollConfiguration_DurationSecond = cmdletContext.PostRollConfiguration_DurationSecond.Value;
            }
            if (requestPostRollConfiguration_postRollConfiguration_DurationSecond != null)
            {
                request.PostRollConfiguration.DurationSeconds = requestPostRollConfiguration_postRollConfiguration_DurationSecond.Value;
                requestPostRollConfigurationIsNull = false;
            }
            System.Boolean? requestPostRollConfiguration_postRollConfiguration_Enabled = null;
            if (cmdletContext.PostRollConfiguration_Enabled != null)
            {
                requestPostRollConfiguration_postRollConfiguration_Enabled = cmdletContext.PostRollConfiguration_Enabled.Value;
            }
            if (requestPostRollConfiguration_postRollConfiguration_Enabled != null)
            {
                request.PostRollConfiguration.Enabled = requestPostRollConfiguration_postRollConfiguration_Enabled.Value;
                requestPostRollConfigurationIsNull = false;
            }
             // determine if request.PostRollConfiguration should be set to null
            if (requestPostRollConfigurationIsNull)
            {
                request.PostRollConfiguration = null;
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
        
        private Amazon.IVS.Model.UpdateAdConfigurationResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.UpdateAdConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "UpdateAdConfiguration");
            try
            {
                return client.UpdateAdConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public List<Amazon.IVS.Model.MediaTailorPlaybackConfiguration> MediaTailorPlaybackConfiguration { get; set; }
            public System.String Name { get; set; }
            public System.Int32? PostRollConfiguration_DurationSecond { get; set; }
            public System.Boolean? PostRollConfiguration_Enabled { get; set; }
            public System.Func<Amazon.IVS.Model.UpdateAdConfigurationResponse, UpdateIVSAdConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AdConfiguration;
        }
        
    }
}
