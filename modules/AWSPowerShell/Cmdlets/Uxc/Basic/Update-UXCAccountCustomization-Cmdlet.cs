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
using Amazon.Uxc;
using Amazon.Uxc.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.UXC
{
    /// <summary>
    /// Updates one or more account customization settings. You can update account color,
    /// visible services, and visible Regions in a single request. Only the settings that
    /// you include in the request body are modified. Omitted settings remain unchanged. To
    /// reset a setting to its default behavior, set the value to <c>null</c> for visible
    /// Regions and visible services, or <c>none</c> for account color. This operation is
    /// idempotent.
    /// 
    ///  <note><para>
    /// The <c>visibleServices</c> and <c>visibleRegions</c> settings control only the appearance
    /// of services and Regions in the Amazon Web Services Management Console. They do not
    /// restrict access through the CLI, SDKs, or other APIs.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "UXCAccountCustomization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Uxc.Model.UpdateAccountCustomizationsResponse")]
    [AWSCmdlet("Calls the AWSAccountUXSetting UpdateAccountCustomizations API operation.", Operation = new[] {"UpdateAccountCustomizations"}, SelectReturnType = typeof(Amazon.Uxc.Model.UpdateAccountCustomizationsResponse))]
    [AWSCmdletOutput("Amazon.Uxc.Model.UpdateAccountCustomizationsResponse",
        "This cmdlet returns an Amazon.Uxc.Model.UpdateAccountCustomizationsResponse object containing multiple properties."
    )]
    public partial class UpdateUXCAccountCustomizationCmdlet : AmazonUxcClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountColor
        /// <summary>
        /// <para>
        /// <para>The account color preference to set. Set to <c>none</c> to reset to the default (no
        /// color).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Uxc.AccountColor")]
        public Amazon.Uxc.AccountColor AccountColor { get; set; }
        #endregion
        
        #region Parameter VisibleRegion
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Web Services Region codes to make visible in the Amazon Web Services
        /// Management Console. Set to <c>null</c> to reset to the default, which makes all Regions
        /// visible. For a list of valid Region codes, see <a href="https://docs.aws.amazon.com/global-infrastructure/latest/regions/aws-regions.html">Amazon
        /// Web Services Regions</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisibleRegions")]
        public System.String[] VisibleRegion { get; set; }
        #endregion
        
        #region Parameter VisibleService
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Web Services service identifiers to make visible in the Amazon
        /// Web Services Management Console. Set to <c>null</c> to reset to the default, which
        /// makes all services visible. For valid service identifiers, call <a href="https://docs.aws.amazon.com/awsconsolehelpdocs/latest/APIReference/API_ListServices.html">ListServices</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisibleServices")]
        public System.String[] VisibleService { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Uxc.Model.UpdateAccountCustomizationsResponse).
        /// Specifying the name of a property of type Amazon.Uxc.Model.UpdateAccountCustomizationsResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-UXCAccountCustomization (UpdateAccountCustomizations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Uxc.Model.UpdateAccountCustomizationsResponse, UpdateUXCAccountCustomizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountColor = this.AccountColor;
            if (this.VisibleRegion != null)
            {
                context.VisibleRegion = new List<System.String>(this.VisibleRegion);
            }
            if (this.VisibleService != null)
            {
                context.VisibleService = new List<System.String>(this.VisibleService);
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
            var request = new Amazon.Uxc.Model.UpdateAccountCustomizationsRequest();
            
            if (cmdletContext.AccountColor != null)
            {
                request.AccountColor = cmdletContext.AccountColor;
            }
            if (cmdletContext.VisibleRegion != null)
            {
                request.VisibleRegions = cmdletContext.VisibleRegion;
            }
            if (cmdletContext.VisibleService != null)
            {
                request.VisibleServices = cmdletContext.VisibleService;
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
        
        private Amazon.Uxc.Model.UpdateAccountCustomizationsResponse CallAWSServiceOperation(IAmazonUxc client, Amazon.Uxc.Model.UpdateAccountCustomizationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSAccountUXSetting", "UpdateAccountCustomizations");
            try
            {
                return client.UpdateAccountCustomizationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Uxc.AccountColor AccountColor { get; set; }
            public List<System.String> VisibleRegion { get; set; }
            public List<System.String> VisibleService { get; set; }
            public System.Func<Amazon.Uxc.Model.UpdateAccountCustomizationsResponse, UpdateUXCAccountCustomizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
