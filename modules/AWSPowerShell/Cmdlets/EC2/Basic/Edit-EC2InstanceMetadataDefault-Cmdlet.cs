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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the default instance metadata service (IMDS) settings at the account level
    /// in the specified Amazon Web Services  Region.
    /// 
    ///  <note><para>
    /// To remove a parameter's account-level default setting, specify <c>no-preference</c>.
    /// If an account-level setting is cleared with <c>no-preference</c>, then the instance
    /// launch considers the other instance metadata settings. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/configuring-instance-metadata-options.html#instance-metadata-options-order-of-precedence">Order
    /// of precedence for instance metadata options</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "EC2InstanceMetadataDefault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyInstanceMetadataDefaults API operation.", Operation = new[] {"ModifyInstanceMetadataDefaults"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2InstanceMetadataDefaultCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the operation, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter HttpEndpoint
        /// <summary>
        /// <para>
        /// <para>Enables or disables the IMDS endpoint on an instance. When disabled, the instance
        /// metadata can't be accessed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DefaultInstanceMetadataEndpointState")]
        public Amazon.EC2.DefaultInstanceMetadataEndpointState HttpEndpoint { get; set; }
        #endregion
        
        #region Parameter HttpPutResponseHopLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of hops that the metadata token can travel. To indicate no preference,
        /// specify <c>-1</c>.</para><para>Possible values: Integers from <c>1</c> to <c>64</c>, and <c>-1</c> to indicate no
        /// preference</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter HttpToken
        /// <summary>
        /// <para>
        /// <para>Indicates whether IMDSv2 is required.</para><ul><li><para><c>optional</c> – IMDSv2 is optional, which means that you can use either IMDSv2
        /// or IMDSv1.</para></li><li><para><c>required</c> – IMDSv2 is required, which means that IMDSv1 is disabled, and you
        /// must use IMDSv2.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HttpTokens")]
        [AWSConstantClassSource("Amazon.EC2.MetadataDefaultHttpTokensState")]
        public Amazon.EC2.MetadataDefaultHttpTokensState HttpToken { get; set; }
        #endregion
        
        #region Parameter InstanceMetadataTag
        /// <summary>
        /// <para>
        /// <para>Enables or disables access to an instance's tags from the instance metadata. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html#work-with-tags-in-IMDS">Work
        /// with instance tags using the instance metadata</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceMetadataTags")]
        [AWSConstantClassSource("Amazon.EC2.DefaultInstanceMetadataTagsState")]
        public Amazon.EC2.DefaultInstanceMetadataTagsState InstanceMetadataTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstanceMetadataDefault (ModifyInstanceMetadataDefaults)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse, EditEC2InstanceMetadataDefaultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.HttpEndpoint = this.HttpEndpoint;
            context.HttpPutResponseHopLimit = this.HttpPutResponseHopLimit;
            context.HttpToken = this.HttpToken;
            context.InstanceMetadataTag = this.InstanceMetadataTag;
            
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
            var request = new Amazon.EC2.Model.ModifyInstanceMetadataDefaultsRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.HttpEndpoint != null)
            {
                request.HttpEndpoint = cmdletContext.HttpEndpoint;
            }
            if (cmdletContext.HttpPutResponseHopLimit != null)
            {
                request.HttpPutResponseHopLimit = cmdletContext.HttpPutResponseHopLimit.Value;
            }
            if (cmdletContext.HttpToken != null)
            {
                request.HttpTokens = cmdletContext.HttpToken;
            }
            if (cmdletContext.InstanceMetadataTag != null)
            {
                request.InstanceMetadataTags = cmdletContext.InstanceMetadataTag;
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
        
        private Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstanceMetadataDefaultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyInstanceMetadataDefaults");
            try
            {
                return client.ModifyInstanceMetadataDefaultsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public Amazon.EC2.DefaultInstanceMetadataEndpointState HttpEndpoint { get; set; }
            public System.Int32? HttpPutResponseHopLimit { get; set; }
            public Amazon.EC2.MetadataDefaultHttpTokensState HttpToken { get; set; }
            public Amazon.EC2.DefaultInstanceMetadataTagsState InstanceMetadataTag { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyInstanceMetadataDefaultsResponse, EditEC2InstanceMetadataDefaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
