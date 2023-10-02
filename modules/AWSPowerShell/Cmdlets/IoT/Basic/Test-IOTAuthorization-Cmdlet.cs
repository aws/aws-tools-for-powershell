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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Tests if a specified principal is authorized to perform an IoT action on a specified
    /// resource. Use this to test and debug the authorization behavior of devices that connect
    /// to the IoT device gateway.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">TestAuthorization</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "IOTAuthorization")]
    [OutputType("Amazon.IoT.Model.AuthResult")]
    [AWSCmdlet("Calls the AWS IoT TestAuthorization API operation.", Operation = new[] {"TestAuthorization"}, SelectReturnType = typeof(Amazon.IoT.Model.TestAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.AuthResult or Amazon.IoT.Model.TestAuthorizationResponse",
        "This cmdlet returns a collection of Amazon.IoT.Model.AuthResult objects.",
        "The service call response (type Amazon.IoT.Model.TestAuthorizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestIOTAuthorizationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthInfo
        /// <summary>
        /// <para>
        /// <para>A list of authorization info objects. Simulating authorization will create a response
        /// for each <code>authInfo</code> object in the list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AuthInfos")]
        public Amazon.IoT.Model.AuthInfo[] AuthInfo { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The MQTT client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter CognitoIdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The Cognito identity pool ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoIdentityPoolId { get; set; }
        #endregion
        
        #region Parameter PolicyNamesToAdd
        /// <summary>
        /// <para>
        /// <para>When testing custom authorization, the policies specified here are treated as if they
        /// are attached to the principal being authorized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PolicyNamesToAdd { get; set; }
        #endregion
        
        #region Parameter PolicyNamesToSkip
        /// <summary>
        /// <para>
        /// <para>When testing custom authorization, the policies specified here are treated as if they
        /// are not attached to the principal being authorized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PolicyNamesToSkip { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The principal. Valid principals are CertificateArn (arn:aws:iot:<i>region</i>:<i>accountId</i>:cert/<i>certificateId</i>),
        /// thingGroupArn (arn:aws:iot:<i>region</i>:<i>accountId</i>:thinggroup/<i>groupName</i>)
        /// and CognitoId (<i>region</i>:<i>id</i>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.TestAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.TestAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthResults";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.TestAuthorizationResponse, TestIOTAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AuthInfo != null)
            {
                context.AuthInfo = new List<Amazon.IoT.Model.AuthInfo>(this.AuthInfo);
            }
            #if MODULAR
            if (this.AuthInfo == null && ParameterWasBound(nameof(this.AuthInfo)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthInfo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientId = this.ClientId;
            context.CognitoIdentityPoolId = this.CognitoIdentityPoolId;
            if (this.PolicyNamesToAdd != null)
            {
                context.PolicyNamesToAdd = new List<System.String>(this.PolicyNamesToAdd);
            }
            if (this.PolicyNamesToSkip != null)
            {
                context.PolicyNamesToSkip = new List<System.String>(this.PolicyNamesToSkip);
            }
            context.Principal = this.Principal;
            
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
            var request = new Amazon.IoT.Model.TestAuthorizationRequest();
            
            if (cmdletContext.AuthInfo != null)
            {
                request.AuthInfos = cmdletContext.AuthInfo;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.CognitoIdentityPoolId != null)
            {
                request.CognitoIdentityPoolId = cmdletContext.CognitoIdentityPoolId;
            }
            if (cmdletContext.PolicyNamesToAdd != null)
            {
                request.PolicyNamesToAdd = cmdletContext.PolicyNamesToAdd;
            }
            if (cmdletContext.PolicyNamesToSkip != null)
            {
                request.PolicyNamesToSkip = cmdletContext.PolicyNamesToSkip;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
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
        
        private Amazon.IoT.Model.TestAuthorizationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.TestAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "TestAuthorization");
            try
            {
                #if DESKTOP
                return client.TestAuthorization(request);
                #elif CORECLR
                return client.TestAuthorizationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoT.Model.AuthInfo> AuthInfo { get; set; }
            public System.String ClientId { get; set; }
            public System.String CognitoIdentityPoolId { get; set; }
            public List<System.String> PolicyNamesToAdd { get; set; }
            public List<System.String> PolicyNamesToSkip { get; set; }
            public System.String Principal { get; set; }
            public System.Func<Amazon.IoT.Model.TestAuthorizationResponse, TestIOTAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthResults;
        }
        
    }
}
