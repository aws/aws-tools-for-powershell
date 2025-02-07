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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Starts delete of resources.
    /// </summary>
    [Cmdlet("Remove", "EMLResourceBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.MediaLive.Model.BatchDeleteResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive BatchDelete API operation.", Operation = new[] {"BatchDelete"}, SelectReturnType = typeof(Amazon.MediaLive.Model.BatchDeleteResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.BatchDeleteResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.BatchDeleteResponse object containing multiple properties."
    )]
    public partial class RemoveEMLResourceBatchCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// List of channel IDs
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelIds")]
        public System.String[] ChannelId { get; set; }
        #endregion
        
        #region Parameter InputId
        /// <summary>
        /// <para>
        /// List of input IDs
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputIds")]
        public System.String[] InputId { get; set; }
        #endregion
        
        #region Parameter InputSecurityGroupId
        /// <summary>
        /// <para>
        /// List of input security group IDs
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputSecurityGroupIds")]
        public System.String[] InputSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter MultiplexId
        /// <summary>
        /// <para>
        /// List of multiplex IDs
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexIds")]
        public System.String[] MultiplexId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.BatchDeleteResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.BatchDeleteResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EMLResourceBatch (BatchDelete)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.BatchDeleteResponse, RemoveEMLResourceBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ChannelId != null)
            {
                context.ChannelId = new List<System.String>(this.ChannelId);
            }
            if (this.InputId != null)
            {
                context.InputId = new List<System.String>(this.InputId);
            }
            if (this.InputSecurityGroupId != null)
            {
                context.InputSecurityGroupId = new List<System.String>(this.InputSecurityGroupId);
            }
            if (this.MultiplexId != null)
            {
                context.MultiplexId = new List<System.String>(this.MultiplexId);
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
            var request = new Amazon.MediaLive.Model.BatchDeleteRequest();
            
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelIds = cmdletContext.ChannelId;
            }
            if (cmdletContext.InputId != null)
            {
                request.InputIds = cmdletContext.InputId;
            }
            if (cmdletContext.InputSecurityGroupId != null)
            {
                request.InputSecurityGroupIds = cmdletContext.InputSecurityGroupId;
            }
            if (cmdletContext.MultiplexId != null)
            {
                request.MultiplexIds = cmdletContext.MultiplexId;
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
        
        private Amazon.MediaLive.Model.BatchDeleteResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.BatchDeleteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "BatchDelete");
            try
            {
                #if DESKTOP
                return client.BatchDelete(request);
                #elif CORECLR
                return client.BatchDeleteAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ChannelId { get; set; }
            public List<System.String> InputId { get; set; }
            public List<System.String> InputSecurityGroupId { get; set; }
            public List<System.String> MultiplexId { get; set; }
            public System.Func<Amazon.MediaLive.Model.BatchDeleteResponse, RemoveEMLResourceBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
