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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Returns the full details of an <c>AppInstanceUser</c>.
    /// </summary>
    [Cmdlet("Get", "CHMIDAppInstanceUser")]
    [OutputType("Amazon.ChimeSDKIdentity.Model.AppInstanceUser")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity DescribeAppInstanceUser API operation.", Operation = new[] {"DescribeAppInstanceUser"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKIdentity.Model.AppInstanceUser or Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse",
        "This cmdlet returns an Amazon.ChimeSDKIdentity.Model.AppInstanceUser object.",
        "The service call response (type Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCHMIDAppInstanceUserCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppInstanceUserArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceUser</c>.</para>
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
        public System.String AppInstanceUserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppInstanceUser'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppInstanceUser";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppInstanceUserArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppInstanceUserArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppInstanceUserArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse, GetCHMIDAppInstanceUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppInstanceUserArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppInstanceUserArn = this.AppInstanceUserArn;
            #if MODULAR
            if (this.AppInstanceUserArn == null && ParameterWasBound(nameof(this.AppInstanceUserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceUserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserRequest();
            
            if (cmdletContext.AppInstanceUserArn != null)
            {
                request.AppInstanceUserArn = cmdletContext.AppInstanceUserArn;
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
        
        private Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "DescribeAppInstanceUser");
            try
            {
                #if DESKTOP
                return client.DescribeAppInstanceUser(request);
                #elif CORECLR
                return client.DescribeAppInstanceUserAsync(request).GetAwaiter().GetResult();
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
            public System.String AppInstanceUserArn { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.DescribeAppInstanceUserResponse, GetCHMIDAppInstanceUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppInstanceUser;
        }
        
    }
}
