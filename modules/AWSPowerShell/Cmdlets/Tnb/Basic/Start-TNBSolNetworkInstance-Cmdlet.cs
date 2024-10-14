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
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Instantiates a network instance.
    /// 
    ///  
    /// <para>
    /// A network instance is a single network created in Amazon Web Services TNB that can
    /// be deployed and on which life-cycle operations (like terminate, update, and delete)
    /// can be performed.
    /// </para><para>
    /// Before you can instantiate a network instance, you have to create a network instance.
    /// For more information, see <a href="https://docs.aws.amazon.com/tnb/latest/APIReference/API_CreateSolNetworkInstance.html">CreateSolNetworkInstance</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "TNBSolNetworkInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Telco Network Builder InstantiateSolNetworkInstance API operation.", Operation = new[] {"InstantiateSolNetworkInstance"}, SelectReturnType = typeof(Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse))]
    [AWSCmdletOutput("System.String or Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTNBSolNetworkInstanceCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalParamsForNs
        /// <summary>
        /// <para>
        /// <para>Provides values for the configurable properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject AdditionalParamsForNs { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A check for whether you have the required permissions for the action without actually
        /// making the request and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter NsInstanceId
        /// <summary>
        /// <para>
        /// <para>ID of the network instance.</para>
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
        public System.String NsInstanceId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A tag is a label that you assign to an Amazon Web Services resource. Each tag consists
        /// of a key and an optional value. When you use this API, the tags are only applied to
        /// the network operation that is created. These tags are not applied to the network instance.
        /// Use tags to search and filter your resources or track your Amazon Web Services costs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NsLcmOpOccId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NsLcmOpOccId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NsInstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NsInstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NsInstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NsInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TNBSolNetworkInstance (InstantiateSolNetworkInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse, StartTNBSolNetworkInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NsInstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdditionalParamsForNs = this.AdditionalParamsForNs;
            context.DryRun = this.DryRun;
            context.NsInstanceId = this.NsInstanceId;
            #if MODULAR
            if (this.NsInstanceId == null && ParameterWasBound(nameof(this.NsInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NsInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Tnb.Model.InstantiateSolNetworkInstanceRequest();
            
            if (cmdletContext.AdditionalParamsForNs != null)
            {
                request.AdditionalParamsForNs = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.AdditionalParamsForNs);
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.NsInstanceId != null)
            {
                request.NsInstanceId = cmdletContext.NsInstanceId;
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
        
        private Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.InstantiateSolNetworkInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "InstantiateSolNetworkInstance");
            try
            {
                #if DESKTOP
                return client.InstantiateSolNetworkInstance(request);
                #elif CORECLR
                return client.InstantiateSolNetworkInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject AdditionalParamsForNs { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String NsInstanceId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Tnb.Model.InstantiateSolNetworkInstanceResponse, StartTNBSolNetworkInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NsLcmOpOccId;
        }
        
    }
}
