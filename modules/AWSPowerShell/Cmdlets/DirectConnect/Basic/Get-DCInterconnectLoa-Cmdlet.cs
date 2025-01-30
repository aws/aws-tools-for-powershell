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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// <note><para>
    /// Deprecated. Use <a>DescribeLoa</a> instead.
    /// </para></note><para>
    /// Gets the LOA-CFA for the specified interconnect.
    /// </para><para>
    /// The Letter of Authorization - Connecting Facility Assignment (LOA-CFA) is a document
    /// that is used when establishing your cross connect to Amazon Web Services at the colocation
    /// facility. For more information, see <a href="https://docs.aws.amazon.com/directconnect/latest/UserGuide/Colocation.html">Requesting
    /// Cross Connects at Direct Connect Locations</a> in the <i>Direct Connect User Guide</i>.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "DCInterconnectLoa")]
    [OutputType("Amazon.DirectConnect.Model.Loa")]
    [AWSCmdlet("Calls the AWS Direct Connect DescribeInterconnectLoa API operation.", Operation = new[] {"DescribeInterconnectLoa"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.Loa or Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.Loa object.",
        "The service call response (type Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Deprecated in favor of DescribeLoa.")]
    public partial class GetDCInterconnectLoaCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InterconnectId
        /// <summary>
        /// <para>
        /// <para>The ID of the interconnect.</para>
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
        public System.String InterconnectId { get; set; }
        #endregion
        
        #region Parameter LoaContentType
        /// <summary>
        /// <para>
        /// <para>The standard media type for the LOA-CFA document. The only supported value is application/pdf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.LoaContentType")]
        public Amazon.DirectConnect.LoaContentType LoaContentType { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the service provider who establishes connectivity on your behalf. If you
        /// supply this parameter, the LOA-CFA lists the provider name alongside your company
        /// name as the requester of the cross connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Loa'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Loa";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InterconnectId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InterconnectId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InterconnectId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse, GetDCInterconnectLoaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InterconnectId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InterconnectId = this.InterconnectId;
            #if MODULAR
            if (this.InterconnectId == null && ParameterWasBound(nameof(this.InterconnectId)))
            {
                WriteWarning("You are passing $null as a value for parameter InterconnectId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoaContentType = this.LoaContentType;
            context.ProviderName = this.ProviderName;
            
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
            var request = new Amazon.DirectConnect.Model.DescribeInterconnectLoaRequest();
            
            if (cmdletContext.InterconnectId != null)
            {
                request.InterconnectId = cmdletContext.InterconnectId;
            }
            if (cmdletContext.LoaContentType != null)
            {
                request.LoaContentType = cmdletContext.LoaContentType;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
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
        
        private Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DescribeInterconnectLoaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DescribeInterconnectLoa");
            try
            {
                #if DESKTOP
                return client.DescribeInterconnectLoa(request);
                #elif CORECLR
                return client.DescribeInterconnectLoaAsync(request).GetAwaiter().GetResult();
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
            public System.String InterconnectId { get; set; }
            public Amazon.DirectConnect.LoaContentType LoaContentType { get; set; }
            public System.String ProviderName { get; set; }
            public System.Func<Amazon.DirectConnect.Model.DescribeInterconnectLoaResponse, GetDCInterconnectLoaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Loa;
        }
        
    }
}
