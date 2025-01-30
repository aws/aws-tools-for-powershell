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
using Amazon.CodeConnections;
using Amazon.CodeConnections.Model;

namespace Amazon.PowerShell.Cmdlets.CCON
{
    /// <summary>
    /// Creates a connection that can then be given to other Amazon Web Services services
    /// like CodePipeline so that it can access third-party code repositories. The connection
    /// is in pending status until the third-party connection handshake is completed from
    /// the console.
    /// </summary>
    [Cmdlet("New", "CCONConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeConnections CreateConnection API operation.", Operation = new[] {"CreateConnection"}, SelectReturnType = typeof(Amazon.CodeConnections.Model.CreateConnectionResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeConnections.Model.CreateConnectionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CodeConnections.Model.CreateConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCCONConnectionCmdlet : AmazonCodeConnectionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection to be created.</para>
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
        public System.String ConnectionName { get; set; }
        #endregion
        
        #region Parameter HostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the host associated with the connection to be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostArn { get; set; }
        #endregion
        
        #region Parameter ProviderType
        /// <summary>
        /// <para>
        /// <para>The name of the external provider where your third-party code repository is configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeConnections.ProviderType")]
        public Amazon.CodeConnections.ProviderType ProviderType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair to use when tagging the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CodeConnections.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeConnections.Model.CreateConnectionResponse).
        /// Specifying the name of a property of type Amazon.CodeConnections.Model.CreateConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCONConnection (CreateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeConnections.Model.CreateConnectionResponse, NewCCONConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectionName = this.ConnectionName;
            #if MODULAR
            if (this.ConnectionName == null && ParameterWasBound(nameof(this.ConnectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostArn = this.HostArn;
            context.ProviderType = this.ProviderType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CodeConnections.Model.Tag>(this.Tag);
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
            var request = new Amazon.CodeConnections.Model.CreateConnectionRequest();
            
            if (cmdletContext.ConnectionName != null)
            {
                request.ConnectionName = cmdletContext.ConnectionName;
            }
            if (cmdletContext.HostArn != null)
            {
                request.HostArn = cmdletContext.HostArn;
            }
            if (cmdletContext.ProviderType != null)
            {
                request.ProviderType = cmdletContext.ProviderType;
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
        
        private Amazon.CodeConnections.Model.CreateConnectionResponse CallAWSServiceOperation(IAmazonCodeConnections client, Amazon.CodeConnections.Model.CreateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeConnections", "CreateConnection");
            try
            {
                #if DESKTOP
                return client.CreateConnection(request);
                #elif CORECLR
                return client.CreateConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectionName { get; set; }
            public System.String HostArn { get; set; }
            public Amazon.CodeConnections.ProviderType ProviderType { get; set; }
            public List<Amazon.CodeConnections.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CodeConnections.Model.CreateConnectionResponse, NewCCONConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectionArn;
        }
        
    }
}
