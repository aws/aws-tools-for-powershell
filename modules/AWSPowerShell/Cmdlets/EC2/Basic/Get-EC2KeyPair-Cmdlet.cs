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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified key pairs or all of your key pairs.
    /// 
    ///  
    /// <para>
    /// For more information about key pairs, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Key
    /// Pairs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2KeyPair")]
    [OutputType("Amazon.EC2.Model.KeyPairInfo")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeKeyPairs API operation.", Operation = new[] {"DescribeKeyPairs"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeKeyPairsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.KeyPairInfo or Amazon.EC2.Model.DescribeKeyPairsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.KeyPairInfo objects.",
        "The service call response (type Amazon.EC2.Model.DescribeKeyPairsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2KeyPairCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><code>key-pair-id</code> - The ID of the key pair.</para></li><li><para><code>fingerprint</code> - The fingerprint of the key pair.</para></li><li><para><code>key-name</code> - The name of the key pair.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter KeyName
        /// <summary>
        /// <para>
        /// <para>The key pair names.</para><para>Default: Describes all your key pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("KeyNames")]
        public System.String[] KeyName { get; set; }
        #endregion
        
        #region Parameter KeyPairId
        /// <summary>
        /// <para>
        /// <para>The IDs of the key pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyPairIds")]
        public System.String[] KeyPairId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KeyPairs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeKeyPairsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeKeyPairsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KeyPairs";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeKeyPairsResponse, GetEC2KeyPairCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.KeyName != null)
            {
                context.KeyName = new List<System.String>(this.KeyName);
            }
            if (this.KeyPairId != null)
            {
                context.KeyPairId = new List<System.String>(this.KeyPairId);
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
            var request = new Amazon.EC2.Model.DescribeKeyPairsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.KeyName != null)
            {
                request.KeyNames = cmdletContext.KeyName;
            }
            if (cmdletContext.KeyPairId != null)
            {
                request.KeyPairIds = cmdletContext.KeyPairId;
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
        
        private Amazon.EC2.Model.DescribeKeyPairsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeKeyPairsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeKeyPairs");
            try
            {
                #if DESKTOP
                return client.DescribeKeyPairs(request);
                #elif CORECLR
                return client.DescribeKeyPairsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> KeyName { get; set; }
            public List<System.String> KeyPairId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeKeyPairsResponse, GetEC2KeyPairCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KeyPairs;
        }
        
    }
}
