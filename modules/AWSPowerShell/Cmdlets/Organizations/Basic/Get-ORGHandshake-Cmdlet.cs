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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Retrieves information about a previously requested handshake. The handshake ID comes
    /// from the response to the original <a>InviteAccountToOrganization</a> operation that
    /// generated the handshake.
    /// 
    ///  
    /// <para>
    /// You can access handshakes that are <c>ACCEPTED</c>, <c>DECLINED</c>, or <c>CANCELED</c>
    /// for only 30 days after they change to that state. They're then deleted and no longer
    /// accessible.
    /// </para><para>
    /// This operation can be called from any account in the organization.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ORGHandshake")]
    [OutputType("Amazon.Organizations.Model.Handshake")]
    [AWSCmdlet("Calls the AWS Organizations DescribeHandshake API operation.", Operation = new[] {"DescribeHandshake"}, SelectReturnType = typeof(Amazon.Organizations.Model.DescribeHandshakeResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.Handshake or Amazon.Organizations.Model.DescribeHandshakeResponse",
        "This cmdlet returns an Amazon.Organizations.Model.Handshake object.",
        "The service call response (type Amazon.Organizations.Model.DescribeHandshakeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetORGHandshakeCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HandshakeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the handshake that you want information about. You can
        /// get the ID from the original call to <a>InviteAccountToOrganization</a>, or from a
        /// call to <a>ListHandshakesForAccount</a> or <a>ListHandshakesForOrganization</a>.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for handshake ID string
        /// requires "h-" followed by from 8 to 32 lowercase letters or digits.</para>
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
        public System.String HandshakeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Handshake'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.DescribeHandshakeResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.DescribeHandshakeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Handshake";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HandshakeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HandshakeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HandshakeId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.DescribeHandshakeResponse, GetORGHandshakeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HandshakeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HandshakeId = this.HandshakeId;
            #if MODULAR
            if (this.HandshakeId == null && ParameterWasBound(nameof(this.HandshakeId)))
            {
                WriteWarning("You are passing $null as a value for parameter HandshakeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Organizations.Model.DescribeHandshakeRequest();
            
            if (cmdletContext.HandshakeId != null)
            {
                request.HandshakeId = cmdletContext.HandshakeId;
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
        
        private Amazon.Organizations.Model.DescribeHandshakeResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DescribeHandshakeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DescribeHandshake");
            try
            {
                #if DESKTOP
                return client.DescribeHandshake(request);
                #elif CORECLR
                return client.DescribeHandshakeAsync(request).GetAwaiter().GetResult();
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
            public System.String HandshakeId { get; set; }
            public System.Func<Amazon.Organizations.Model.DescribeHandshakeResponse, GetORGHandshakeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Handshake;
        }
        
    }
}
