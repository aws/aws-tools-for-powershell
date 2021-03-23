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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Associates a partner account with your AWS account.
    /// </summary>
    [Cmdlet("Join", "IOTWAwsAccountWithPartnerAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.SidewalkAccountInfo")]
    [AWSCmdlet("Calls the AWS IoT Wireless AssociateAwsAccountWithPartnerAccount API operation.", Operation = new[] {"AssociateAwsAccountWithPartnerAccount"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.SidewalkAccountInfo or Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.SidewalkAccountInfo object.",
        "The service call response (type Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class JoinIOTWAwsAccountWithPartnerAccountCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        #region Parameter Sidewalk_AmazonId
        /// <summary>
        /// <para>
        /// <para>The Sidewalk Amazon ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sidewalk_AmazonId { get; set; }
        #endregion
        
        #region Parameter Sidewalk_AppServerPrivateKey
        /// <summary>
        /// <para>
        /// <para>The Sidewalk application server private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sidewalk_AppServerPrivateKey { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Each resource must have a unique client request token. If you try to create a new
        /// resource with the same token as a resource that already exists, an exception occurs.
        /// If you omit this value, AWS SDKs will automatically generate a unique client request.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the specified resource. Tags are metadata that you can use to
        /// manage a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Sidewalk'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Sidewalk";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClientRequestToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClientRequestToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClientRequestToken' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Sidewalk_AmazonId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Join-IOTWAwsAccountWithPartnerAccount (AssociateAwsAccountWithPartnerAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse, JoinIOTWAwsAccountWithPartnerAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClientRequestToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Sidewalk_AmazonId = this.Sidewalk_AmazonId;
            context.Sidewalk_AppServerPrivateKey = this.Sidewalk_AppServerPrivateKey;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTWireless.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Sidewalk
            var requestSidewalkIsNull = true;
            request.Sidewalk = new Amazon.IoTWireless.Model.SidewalkAccountInfo();
            System.String requestSidewalk_sidewalk_AmazonId = null;
            if (cmdletContext.Sidewalk_AmazonId != null)
            {
                requestSidewalk_sidewalk_AmazonId = cmdletContext.Sidewalk_AmazonId;
            }
            if (requestSidewalk_sidewalk_AmazonId != null)
            {
                request.Sidewalk.AmazonId = requestSidewalk_sidewalk_AmazonId;
                requestSidewalkIsNull = false;
            }
            System.String requestSidewalk_sidewalk_AppServerPrivateKey = null;
            if (cmdletContext.Sidewalk_AppServerPrivateKey != null)
            {
                requestSidewalk_sidewalk_AppServerPrivateKey = cmdletContext.Sidewalk_AppServerPrivateKey;
            }
            if (requestSidewalk_sidewalk_AppServerPrivateKey != null)
            {
                request.Sidewalk.AppServerPrivateKey = requestSidewalk_sidewalk_AppServerPrivateKey;
                requestSidewalkIsNull = false;
            }
             // determine if request.Sidewalk should be set to null
            if (requestSidewalkIsNull)
            {
                request.Sidewalk = null;
            }
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
        
        private Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "AssociateAwsAccountWithPartnerAccount");
            try
            {
                #if DESKTOP
                return client.AssociateAwsAccountWithPartnerAccount(request);
                #elif CORECLR
                return client.AssociateAwsAccountWithPartnerAccountAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Sidewalk_AmazonId { get; set; }
            public System.String Sidewalk_AppServerPrivateKey { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTWireless.Model.AssociateAwsAccountWithPartnerAccountResponse, JoinIOTWAwsAccountWithPartnerAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Sidewalk;
        }
        
    }
}
