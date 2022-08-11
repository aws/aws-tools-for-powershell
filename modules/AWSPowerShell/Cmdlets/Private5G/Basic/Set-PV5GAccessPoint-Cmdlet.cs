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
using Amazon.Private5G;
using Amazon.Private5G.Model;

namespace Amazon.PowerShell.Cmdlets.PV5G
{
    /// <summary>
    /// Configures the specified network resource. 
    /// 
    ///  
    /// <para>
    ///  Use this action to specify the geographic position of the hardware. You must provide
    /// Certified Professional Installer (CPI) credentials in the request so that we can obtain
    /// spectrum grants. For more information, see <a href="https://docs.aws.amazon.com/private-networks/latest/userguide/radio-units.html">Radio
    /// units</a> in the <i>Amazon Web Services Private 5G User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Set", "PV5GAccessPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Private5G.Model.NetworkResource")]
    [AWSCmdlet("Calls the AWS Private 5G ConfigureAccessPoint API operation.", Operation = new[] {"ConfigureAccessPoint"}, SelectReturnType = typeof(Amazon.Private5G.Model.ConfigureAccessPointResponse))]
    [AWSCmdletOutput("Amazon.Private5G.Model.NetworkResource or Amazon.Private5G.Model.ConfigureAccessPointResponse",
        "This cmdlet returns an Amazon.Private5G.Model.NetworkResource object.",
        "The service call response (type Amazon.Private5G.Model.ConfigureAccessPointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetPV5GAccessPointCmdlet : AmazonPrivate5GClientCmdlet, IExecutor
    {
        
        #region Parameter AccessPointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network resource.</para>
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
        public System.String AccessPointArn { get; set; }
        #endregion
        
        #region Parameter CpiSecretKey
        /// <summary>
        /// <para>
        /// <para>A Base64 encoded string of the CPI certificate associated with the CPI user who is
        /// certifying the coordinates of the network resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CpiSecretKey { get; set; }
        #endregion
        
        #region Parameter CpiUserId
        /// <summary>
        /// <para>
        /// <para>The CPI user ID of the CPI user who is certifying the coordinates of the network resource.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CpiUserId { get; set; }
        #endregion
        
        #region Parameter CpiUsername
        /// <summary>
        /// <para>
        /// <para>The CPI user name of the CPI user who is certifying the coordinates of the radio unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CpiUsername { get; set; }
        #endregion
        
        #region Parameter CpiUserPassword
        /// <summary>
        /// <para>
        /// <para>The CPI password associated with the CPI certificate in <code>cpiSecretKey</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CpiUserPassword { get; set; }
        #endregion
        
        #region Parameter Position_Elevation
        /// <summary>
        /// <para>
        /// <para>The elevation of the equipment at this position.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Position_Elevation { get; set; }
        #endregion
        
        #region Parameter Position_ElevationReference
        /// <summary>
        /// <para>
        /// <para>The reference point from which elevation is reported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Private5G.ElevationReference")]
        public Amazon.Private5G.ElevationReference Position_ElevationReference { get; set; }
        #endregion
        
        #region Parameter Position_ElevationUnit
        /// <summary>
        /// <para>
        /// <para>The units used to measure the elevation of the position.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Private5G.ElevationUnit")]
        public Amazon.Private5G.ElevationUnit Position_ElevationUnit { get; set; }
        #endregion
        
        #region Parameter Position_Latitude
        /// <summary>
        /// <para>
        /// <para>The latitude of the position.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Position_Latitude { get; set; }
        #endregion
        
        #region Parameter Position_Longitude
        /// <summary>
        /// <para>
        /// <para>The longitude of the position.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Position_Longitude { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessPoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Private5G.Model.ConfigureAccessPointResponse).
        /// Specifying the name of a property of type Amazon.Private5G.Model.ConfigureAccessPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessPoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccessPointArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccessPointArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccessPointArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccessPointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-PV5GAccessPoint (ConfigureAccessPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Private5G.Model.ConfigureAccessPointResponse, SetPV5GAccessPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccessPointArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessPointArn = this.AccessPointArn;
            #if MODULAR
            if (this.AccessPointArn == null && ParameterWasBound(nameof(this.AccessPointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessPointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CpiSecretKey = this.CpiSecretKey;
            context.CpiUserId = this.CpiUserId;
            context.CpiUsername = this.CpiUsername;
            context.CpiUserPassword = this.CpiUserPassword;
            context.Position_Elevation = this.Position_Elevation;
            context.Position_ElevationReference = this.Position_ElevationReference;
            context.Position_ElevationUnit = this.Position_ElevationUnit;
            context.Position_Latitude = this.Position_Latitude;
            context.Position_Longitude = this.Position_Longitude;
            
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
            var request = new Amazon.Private5G.Model.ConfigureAccessPointRequest();
            
            if (cmdletContext.AccessPointArn != null)
            {
                request.AccessPointArn = cmdletContext.AccessPointArn;
            }
            if (cmdletContext.CpiSecretKey != null)
            {
                request.CpiSecretKey = cmdletContext.CpiSecretKey;
            }
            if (cmdletContext.CpiUserId != null)
            {
                request.CpiUserId = cmdletContext.CpiUserId;
            }
            if (cmdletContext.CpiUsername != null)
            {
                request.CpiUsername = cmdletContext.CpiUsername;
            }
            if (cmdletContext.CpiUserPassword != null)
            {
                request.CpiUserPassword = cmdletContext.CpiUserPassword;
            }
            
             // populate Position
            var requestPositionIsNull = true;
            request.Position = new Amazon.Private5G.Model.Position();
            System.Double? requestPosition_position_Elevation = null;
            if (cmdletContext.Position_Elevation != null)
            {
                requestPosition_position_Elevation = cmdletContext.Position_Elevation.Value;
            }
            if (requestPosition_position_Elevation != null)
            {
                request.Position.Elevation = requestPosition_position_Elevation.Value;
                requestPositionIsNull = false;
            }
            Amazon.Private5G.ElevationReference requestPosition_position_ElevationReference = null;
            if (cmdletContext.Position_ElevationReference != null)
            {
                requestPosition_position_ElevationReference = cmdletContext.Position_ElevationReference;
            }
            if (requestPosition_position_ElevationReference != null)
            {
                request.Position.ElevationReference = requestPosition_position_ElevationReference;
                requestPositionIsNull = false;
            }
            Amazon.Private5G.ElevationUnit requestPosition_position_ElevationUnit = null;
            if (cmdletContext.Position_ElevationUnit != null)
            {
                requestPosition_position_ElevationUnit = cmdletContext.Position_ElevationUnit;
            }
            if (requestPosition_position_ElevationUnit != null)
            {
                request.Position.ElevationUnit = requestPosition_position_ElevationUnit;
                requestPositionIsNull = false;
            }
            System.Double? requestPosition_position_Latitude = null;
            if (cmdletContext.Position_Latitude != null)
            {
                requestPosition_position_Latitude = cmdletContext.Position_Latitude.Value;
            }
            if (requestPosition_position_Latitude != null)
            {
                request.Position.Latitude = requestPosition_position_Latitude.Value;
                requestPositionIsNull = false;
            }
            System.Double? requestPosition_position_Longitude = null;
            if (cmdletContext.Position_Longitude != null)
            {
                requestPosition_position_Longitude = cmdletContext.Position_Longitude.Value;
            }
            if (requestPosition_position_Longitude != null)
            {
                request.Position.Longitude = requestPosition_position_Longitude.Value;
                requestPositionIsNull = false;
            }
             // determine if request.Position should be set to null
            if (requestPositionIsNull)
            {
                request.Position = null;
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
        
        private Amazon.Private5G.Model.ConfigureAccessPointResponse CallAWSServiceOperation(IAmazonPrivate5G client, Amazon.Private5G.Model.ConfigureAccessPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Private 5G", "ConfigureAccessPoint");
            try
            {
                #if DESKTOP
                return client.ConfigureAccessPoint(request);
                #elif CORECLR
                return client.ConfigureAccessPointAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessPointArn { get; set; }
            public System.String CpiSecretKey { get; set; }
            public System.String CpiUserId { get; set; }
            public System.String CpiUsername { get; set; }
            public System.String CpiUserPassword { get; set; }
            public System.Double? Position_Elevation { get; set; }
            public Amazon.Private5G.ElevationReference Position_ElevationReference { get; set; }
            public Amazon.Private5G.ElevationUnit Position_ElevationUnit { get; set; }
            public System.Double? Position_Latitude { get; set; }
            public System.Double? Position_Longitude { get; set; }
            public System.Func<Amazon.Private5G.Model.ConfigureAccessPointResponse, SetPV5GAccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessPoint;
        }
        
    }
}
