/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// This operation activates the gateway you previously deployed on your host. For more
    /// information, see <a href="http://docs.aws.amazon.com/storagegateway/latest/userguide/GettingStartedActivateGateway-common.html">
    /// Activate the AWS Storage Gateway</a>. In the activation process, you specify information
    /// such as the region you want to use for storing snapshots, the time zone for scheduled
    /// snapshots the gateway snapshot schedule window, an activation key, and a name for
    /// your gateway. The activation process also associates your gateway with your account;
    /// for more information, see <a>UpdateGatewayInformation</a>.
    /// 
    ///  <note>You must turn on the gateway VM before you can activate your gateway.</note>
    /// </summary>
    [Cmdlet("Enable", "SGGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ActivateGateway operation against AWS Storage Gateway.", Operation = new[] {"ActivateGateway"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type ActivateGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EnableSGGatewayCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Your gateway activation key. You can obtain the activation key by sending an HTTP
        /// GET request with redirects enabled to the gateway IP address (port 80). The redirect
        /// URL returned in the response provides you the activation key for your gateway in the
        /// query string parameter <code>activationKey</code>. It may also include other activation-related
        /// parameters, however, these are merely defaults -- the arguments you pass to the <code>ActivateGateway</code>
        /// API call determine the actual configuration of your gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String ActivationKey { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String GatewayName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One of the values that indicates the region where you want to store the snapshot backups.
        /// The gateway region specified must be the same region as the region in your <code>Host</code>
        /// header in the request. For more information about available regions and endpoints
        /// for AWS Storage Gateway, see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html#sg_region">Regions
        /// and Endpoints</a> in the <i>Amazon Web Services Glossary</i>.</para><para><i>Valid Values</i>: "us-east-1", "us-west-1", "us-west-2", "eu-west-1", "eu-central-1",
        /// "ap-northeast-1", "ap-southeast-1", "ap-southeast-2", "sa-east-1"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public String GatewayRegion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One of the values that indicates the time zone you want to set for the gateway. The
        /// time zone is used, for example, for scheduling snapshots and your gateway's maintenance
        /// schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String GatewayTimezone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One of the values that defines the type of gateway to activate. The type specified
        /// is critical to all later functions of the gateway and cannot be changed after activation.
        /// The default value is <code>STORED</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public String GatewayType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The value that indicates the type of medium changer to use for gateway-VTL. This field
        /// is optional.</para><para><i>Valid Values</i>: "STK-L700", "AWS-Gateway-VTL"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String MediumChangerType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The value that indicates the type of tape drive to use for gateway-VTL. This field
        /// is optional. </para><para><i>Valid Values</i>: "IBM-ULT3580-TD5" </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TapeDriveType { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GatewayName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-SGGateway (ActivateGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ActivationKey = this.ActivationKey;
            context.GatewayName = this.GatewayName;
            context.GatewayRegion = this.GatewayRegion;
            context.GatewayTimezone = this.GatewayTimezone;
            context.GatewayType = this.GatewayType;
            context.MediumChangerType = this.MediumChangerType;
            context.TapeDriveType = this.TapeDriveType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ActivateGatewayRequest();
            
            if (cmdletContext.ActivationKey != null)
            {
                request.ActivationKey = cmdletContext.ActivationKey;
            }
            if (cmdletContext.GatewayName != null)
            {
                request.GatewayName = cmdletContext.GatewayName;
            }
            if (cmdletContext.GatewayRegion != null)
            {
                request.GatewayRegion = cmdletContext.GatewayRegion;
            }
            if (cmdletContext.GatewayTimezone != null)
            {
                request.GatewayTimezone = cmdletContext.GatewayTimezone;
            }
            if (cmdletContext.GatewayType != null)
            {
                request.GatewayType = cmdletContext.GatewayType;
            }
            if (cmdletContext.MediumChangerType != null)
            {
                request.MediumChangerType = cmdletContext.MediumChangerType;
            }
            if (cmdletContext.TapeDriveType != null)
            {
                request.TapeDriveType = cmdletContext.TapeDriveType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ActivateGateway(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GatewayARN;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String ActivationKey { get; set; }
            public String GatewayName { get; set; }
            public String GatewayRegion { get; set; }
            public String GatewayTimezone { get; set; }
            public String GatewayType { get; set; }
            public String MediumChangerType { get; set; }
            public String TapeDriveType { get; set; }
        }
        
    }
}
