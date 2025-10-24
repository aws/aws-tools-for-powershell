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
using Amazon.LocationService;
using Amazon.LocationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Amazon.LocationService.IAmazonLocationService.CreateRouteCalculator
    /// </summary>
    [Cmdlet("New", "LOCRouteCalculator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.CreateRouteCalculatorResponse")]
    [AWSCmdlet("Calls the Amazon Location Service CreateRouteCalculator API operation.", Operation = new[] {"CreateRouteCalculator"}, SelectReturnType = typeof(Amazon.LocationService.Model.CreateRouteCalculatorResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.CreateRouteCalculatorResponse",
        "This cmdlet returns an Amazon.LocationService.Model.CreateRouteCalculatorResponse object containing multiple properties."
    )]
    public partial class NewLOCRouteCalculatorCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CalculatorName
        /// <summary>
        /// <para>
        /// <para>The name of the route calculator resource. </para><para>Requirements:</para><ul><li><para>Can use alphanumeric characters (A–Z, a–z, 0–9) , hyphens (-), periods (.), and underscores
        /// (_).</para></li><li><para>Must be a unique Route calculator resource name.</para></li><li><para>No spaces allowed. For example, <c>ExampleRouteCalculator</c>.</para></li></ul>
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
        public System.String CalculatorName { get; set; }
        #endregion
        
        #region Parameter DataSource
        /// <summary>
        /// <para>
        /// <para>Specifies the data provider of traffic and road network data.</para><note><para>This field is case-sensitive. Enter the valid values as shown. For example, entering
        /// <c>HERE</c> returns an error.</para></note><para>Valid values include:</para><ul><li><para><c>Esri</c> – For additional information about <a href="https://docs.aws.amazon.com/location/previous/developerguide/esri.html">Esri</a>'s
        /// coverage in your region of interest, see <a href="https://doc.arcgis.com/en/arcgis-online/reference/network-coverage.htm">Esri
        /// details on street networks and traffic coverage</a>.</para><para>Route calculators that use Esri as a data source only calculate routes that are shorter
        /// than 400 km.</para></li><li><para><c>Grab</c> – Grab provides routing functionality for Southeast Asia. For additional
        /// information about <a href="https://docs.aws.amazon.com/location/previous/developerguide/grab.html">GrabMaps</a>'
        /// coverage, see <a href="https://docs.aws.amazon.com/location/previous/developerguide/grab.html#grab-coverage-area">GrabMaps
        /// countries and areas covered</a>.</para></li><li><para><c>Here</c> – For additional information about <a href="https://docs.aws.amazon.com/location/previous/developerguide/HERE.html">HERE
        /// Technologies</a>' coverage in your region of interest, see <a href="https://developer.here.com/documentation/routing-api/dev_guide/topics/coverage/car-routing.html">HERE
        /// car routing coverage</a> and <a href="https://developer.here.com/documentation/routing-api/dev_guide/topics/coverage/truck-routing.html">HERE
        /// truck routing coverage</a>.</para></li></ul><para>For additional information , see <a href="https://docs.aws.amazon.com/location/previous/developerguide/what-is-data-provider.html">Data
        /// providers</a> on the <i>Amazon Location Service Developer Guide</i>.</para>
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
        public System.String DataSource { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The optional description for the route calculator resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Applies one or more tags to the route calculator resource. A tag is a key-value pair
        /// helps manage, identify, search, and filter your resources by labelling them.</para><ul><li><para>For example: { <c>"tag1" : "value1"</c>, <c>"tag2" : "value2"</c>}</para></li></ul><para>Format: <c>"key" : "value"</c></para><para>Restrictions:</para><ul><li><para>Maximum 50 tags per resource</para></li><li><para>Each resource tag must be unique with a maximum of one value.</para></li><li><para>Maximum key length: 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length: 256 Unicode characters in UTF-8</para></li><li><para>Can use alphanumeric characters (A–Z, a–z, 0–9), and the following characters: + -
        /// = . _ : / @. </para></li><li><para>Cannot use "aws:" as a prefix for a key.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// <para>No longer used. If included, the only allowed value is <c>RequestBasedUsage</c>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Deprecated. If included, the only allowed value is RequestBasedUsage.")]
        [AWSConstantClassSource("Amazon.LocationService.PricingPlan")]
        public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.CreateRouteCalculatorResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.CreateRouteCalculatorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CalculatorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LOCRouteCalculator (CreateRouteCalculator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.CreateRouteCalculatorResponse, NewLOCRouteCalculatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CalculatorName = this.CalculatorName;
            #if MODULAR
            if (this.CalculatorName == null && ParameterWasBound(nameof(this.CalculatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter CalculatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSource = this.DataSource;
            #if MODULAR
            if (this.DataSource == null && ParameterWasBound(nameof(this.DataSource)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PricingPlan = this.PricingPlan;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.LocationService.Model.CreateRouteCalculatorRequest();
            
            if (cmdletContext.CalculatorName != null)
            {
                request.CalculatorName = cmdletContext.CalculatorName;
            }
            if (cmdletContext.DataSource != null)
            {
                request.DataSource = cmdletContext.DataSource;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.PricingPlan != null)
            {
                request.PricingPlan = cmdletContext.PricingPlan;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LocationService.Model.CreateRouteCalculatorResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.CreateRouteCalculatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "CreateRouteCalculator");
            try
            {
                return client.CreateRouteCalculatorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CalculatorName { get; set; }
            public System.String DataSource { get; set; }
            public System.String Description { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LocationService.Model.CreateRouteCalculatorResponse, NewLOCRouteCalculatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
