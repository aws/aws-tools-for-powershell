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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Update the physical and logistical details for a rack at a site. For more information
    /// about hardware requirements for racks, see <a href="https://docs.aws.amazon.com/outposts/latest/userguide/outposts-requirements.html#checklist">Network
    /// readiness checklist</a> in the Amazon Web Services Outposts User Guide. 
    /// 
    ///  
    /// <para>
    /// To update a rack at a site with an order of <c>IN_PROGRESS</c>, you must wait for
    /// the order to complete or cancel the order.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OUTPSiteRackPhysicalProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.Site")]
    [AWSCmdlet("Calls the AWS Outposts UpdateSiteRackPhysicalProperties API operation.", Operation = new[] {"UpdateSiteRackPhysicalProperties"}, SelectReturnType = typeof(Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.Site or Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse",
        "This cmdlet returns an Amazon.Outposts.Model.Site object.",
        "The service call response (type Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOUTPSiteRackPhysicalPropertyCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FiberOpticCableType
        /// <summary>
        /// <para>
        /// <para>The type of fiber that you will use to attach the Outpost to your network. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.FiberOpticCableType")]
        public Amazon.Outposts.FiberOpticCableType FiberOpticCableType { get; set; }
        #endregion
        
        #region Parameter MaximumSupportedWeightLb
        /// <summary>
        /// <para>
        /// <para>The maximum rack weight that this site can support. <c>NO_LIMIT</c> is over 2000lbs.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumSupportedWeightLbs")]
        [AWSConstantClassSource("Amazon.Outposts.MaximumSupportedWeightLbs")]
        public Amazon.Outposts.MaximumSupportedWeightLbs MaximumSupportedWeightLb { get; set; }
        #endregion
        
        #region Parameter OpticalStandard
        /// <summary>
        /// <para>
        /// <para>The type of optical standard that you will use to attach the Outpost to your network.
        /// This field is dependent on uplink speed, fiber type, and distance to the upstream
        /// device. For more information about networking requirements for racks, see <a href="https://docs.aws.amazon.com/outposts/latest/userguide/outposts-requirements.html#facility-networking">Network</a>
        /// in the Amazon Web Services Outposts User Guide. </para><ul><li><para><c>OPTIC_10GBASE_SR</c>: 10GBASE-SR</para></li><li><para><c>OPTIC_10GBASE_IR</c>: 10GBASE-IR</para></li><li><para><c>OPTIC_10GBASE_LR</c>: 10GBASE-LR</para></li><li><para><c>OPTIC_40GBASE_SR</c>: 40GBASE-SR</para></li><li><para><c>OPTIC_40GBASE_ESR</c>: 40GBASE-ESR</para></li><li><para><c>OPTIC_40GBASE_IR4_LR4L</c>: 40GBASE-IR (LR4L)</para></li><li><para><c>OPTIC_40GBASE_LR4</c>: 40GBASE-LR4</para></li><li><para><c>OPTIC_100GBASE_SR4</c>: 100GBASE-SR4</para></li><li><para><c>OPTIC_100GBASE_CWDM4</c>: 100GBASE-CWDM4</para></li><li><para><c>OPTIC_100GBASE_LR4</c>: 100GBASE-LR4</para></li><li><para><c>OPTIC_100G_PSM4_MSA</c>: 100G PSM4 MSA</para></li><li><para><c>OPTIC_1000BASE_LX</c>: 1000Base-LX</para></li><li><para><c>OPTIC_1000BASE_SX</c> : 1000Base-SX</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.OpticalStandard")]
        public Amazon.Outposts.OpticalStandard OpticalStandard { get; set; }
        #endregion
        
        #region Parameter PowerConnector
        /// <summary>
        /// <para>
        /// <para>The power connector that Amazon Web Services should plan to provide for connections
        /// to the hardware. Note the correlation between <c>PowerPhase</c> and <c>PowerConnector</c>.
        /// </para><ul><li><para>Single-phase AC feed</para><ul><li><para><b>L6-30P</b> – (common in US); 30A; single phase</para></li><li><para><b>IEC309 (blue)</b> – P+N+E, 6hr; 32 A; single phase</para></li></ul></li><li><para>Three-phase AC feed</para><ul><li><para><b>AH530P7W (red)</b> – 3P+N+E, 7hr; 30A; three phase</para></li><li><para><b>AH532P6W (red)</b> – 3P+N+E, 6hr; 32A; three phase</para></li><li><para><b>CS8365C</b> – (common in US); 3P+E, 50A; three phase</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerConnector")]
        public Amazon.Outposts.PowerConnector PowerConnector { get; set; }
        #endregion
        
        #region Parameter PowerDrawKva
        /// <summary>
        /// <para>
        /// <para>The power draw, in kVA, available at the hardware placement position for the rack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerDrawKva")]
        public Amazon.Outposts.PowerDrawKva PowerDrawKva { get; set; }
        #endregion
        
        #region Parameter PowerFeedDrop
        /// <summary>
        /// <para>
        /// <para>Indicates whether the power feed comes above or below the rack. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerFeedDrop")]
        public Amazon.Outposts.PowerFeedDrop PowerFeedDrop { get; set; }
        #endregion
        
        #region Parameter PowerPhase
        /// <summary>
        /// <para>
        /// <para>The power option that you can provide for hardware. </para><ul><li><para>Single-phase AC feed: 200 V to 277 V, 50 Hz or 60 Hz</para></li><li><para>Three-phase AC feed: 346 V to 480 V, 50 Hz or 60 Hz</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerPhase")]
        public Amazon.Outposts.PowerPhase PowerPhase { get; set; }
        #endregion
        
        #region Parameter SiteId
        /// <summary>
        /// <para>
        /// <para> The ID or the Amazon Resource Name (ARN) of the site. </para>
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
        public System.String SiteId { get; set; }
        #endregion
        
        #region Parameter UplinkCount
        /// <summary>
        /// <para>
        /// <para>Racks come with two Outpost network devices. Depending on the supported uplink speed
        /// at the site, the Outpost network devices provide a variable number of uplinks. Specify
        /// the number of uplinks for each Outpost network device that you intend to use to connect
        /// the rack to your network. Note the correlation between <c>UplinkGbps</c> and <c>UplinkCount</c>.
        /// </para><ul><li><para>1Gbps - Uplinks available: 1, 2, 4, 6, 8</para></li><li><para>10Gbps - Uplinks available: 1, 2, 4, 8, 12, 16</para></li><li><para>40 and 100 Gbps- Uplinks available: 1, 2, 4</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.UplinkCount")]
        public Amazon.Outposts.UplinkCount UplinkCount { get; set; }
        #endregion
        
        #region Parameter UplinkGbp
        /// <summary>
        /// <para>
        /// <para>The uplink speed the rack should support for the connection to the Region. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UplinkGbps")]
        [AWSConstantClassSource("Amazon.Outposts.UplinkGbps")]
        public Amazon.Outposts.UplinkGbps UplinkGbp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Site'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Site";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SiteId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SiteId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SiteId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SiteId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OUTPSiteRackPhysicalProperty (UpdateSiteRackPhysicalProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse, UpdateOUTPSiteRackPhysicalPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SiteId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FiberOpticCableType = this.FiberOpticCableType;
            context.MaximumSupportedWeightLb = this.MaximumSupportedWeightLb;
            context.OpticalStandard = this.OpticalStandard;
            context.PowerConnector = this.PowerConnector;
            context.PowerDrawKva = this.PowerDrawKva;
            context.PowerFeedDrop = this.PowerFeedDrop;
            context.PowerPhase = this.PowerPhase;
            context.SiteId = this.SiteId;
            #if MODULAR
            if (this.SiteId == null && ParameterWasBound(nameof(this.SiteId)))
            {
                WriteWarning("You are passing $null as a value for parameter SiteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UplinkCount = this.UplinkCount;
            context.UplinkGbp = this.UplinkGbp;
            
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
            var request = new Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesRequest();
            
            if (cmdletContext.FiberOpticCableType != null)
            {
                request.FiberOpticCableType = cmdletContext.FiberOpticCableType;
            }
            if (cmdletContext.MaximumSupportedWeightLb != null)
            {
                request.MaximumSupportedWeightLbs = cmdletContext.MaximumSupportedWeightLb;
            }
            if (cmdletContext.OpticalStandard != null)
            {
                request.OpticalStandard = cmdletContext.OpticalStandard;
            }
            if (cmdletContext.PowerConnector != null)
            {
                request.PowerConnector = cmdletContext.PowerConnector;
            }
            if (cmdletContext.PowerDrawKva != null)
            {
                request.PowerDrawKva = cmdletContext.PowerDrawKva;
            }
            if (cmdletContext.PowerFeedDrop != null)
            {
                request.PowerFeedDrop = cmdletContext.PowerFeedDrop;
            }
            if (cmdletContext.PowerPhase != null)
            {
                request.PowerPhase = cmdletContext.PowerPhase;
            }
            if (cmdletContext.SiteId != null)
            {
                request.SiteId = cmdletContext.SiteId;
            }
            if (cmdletContext.UplinkCount != null)
            {
                request.UplinkCount = cmdletContext.UplinkCount;
            }
            if (cmdletContext.UplinkGbp != null)
            {
                request.UplinkGbps = cmdletContext.UplinkGbp;
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
        
        private Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "UpdateSiteRackPhysicalProperties");
            try
            {
                #if DESKTOP
                return client.UpdateSiteRackPhysicalProperties(request);
                #elif CORECLR
                return client.UpdateSiteRackPhysicalPropertiesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Outposts.FiberOpticCableType FiberOpticCableType { get; set; }
            public Amazon.Outposts.MaximumSupportedWeightLbs MaximumSupportedWeightLb { get; set; }
            public Amazon.Outposts.OpticalStandard OpticalStandard { get; set; }
            public Amazon.Outposts.PowerConnector PowerConnector { get; set; }
            public Amazon.Outposts.PowerDrawKva PowerDrawKva { get; set; }
            public Amazon.Outposts.PowerFeedDrop PowerFeedDrop { get; set; }
            public Amazon.Outposts.PowerPhase PowerPhase { get; set; }
            public System.String SiteId { get; set; }
            public Amazon.Outposts.UplinkCount UplinkCount { get; set; }
            public Amazon.Outposts.UplinkGbps UplinkGbp { get; set; }
            public System.Func<Amazon.Outposts.Model.UpdateSiteRackPhysicalPropertiesResponse, UpdateOUTPSiteRackPhysicalPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Site;
        }
        
    }
}
