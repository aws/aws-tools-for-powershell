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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Removes tags from the specified Kinesis data stream. Removed tags are deleted and
    /// cannot be recovered after this operation successfully completes.
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// If you specify a tag that does not exist, it is ignored.
    /// </para><para><a>RemoveTagsFromStream</a> has a limit of five transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "KINTagsFromStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis RemoveTagsFromStream API operation.", Operation = new[] {"RemoveTagsFromStream"}, SelectReturnType = typeof(Amazon.Kinesis.Model.RemoveTagsFromStreamResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.RemoveTagsFromStreamResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.RemoveTagsFromStreamResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveKINTagsFromStreamCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter TagKey
        /// <summary>
        /// <para>
        /// <para>A list of tag keys. Each corresponding tag is removed from the stream.</para>
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
        [Alias("TagKeys")]
        public System.String[] TagKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.RemoveTagsFromStreamResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the collection of tag keys that were removed
        /// The -PassThru parameter is deprecated, use -Select instead. This parameter will be removed in future
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-KINTagsFromStream (RemoveTagsFromStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.RemoveTagsFromStreamResponse, RemoveKINTagsFromStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => context.TagKey;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            if (this.TagKey != null)
            {
                context.TagKey = new List<System.String>(this.TagKey);
            }
            #if MODULAR
            if (this.TagKey == null && ParameterWasBound(nameof(this.TagKey)))
            {
                WriteWarning("You are passing $null as a value for parameter TagKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.RemoveTagsFromStreamRequest();
            
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            if (cmdletContext.TagKey != null)
            {
                request.TagKeys = cmdletContext.TagKey;
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
        
        private Amazon.Kinesis.Model.RemoveTagsFromStreamResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.RemoveTagsFromStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "RemoveTagsFromStream");
            try
            {
                #if DESKTOP
                return client.RemoveTagsFromStream(request);
                #elif CORECLR
                return client.RemoveTagsFromStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public List<System.String> TagKey { get; set; }
            public System.Func<Amazon.Kinesis.Model.RemoveTagsFromStreamResponse, RemoveKINTagsFromStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
