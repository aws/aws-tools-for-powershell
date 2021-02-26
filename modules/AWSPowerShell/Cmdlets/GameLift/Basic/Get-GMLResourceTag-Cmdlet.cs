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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves all tags that are assigned to a GameLift resource. Resource tags are used
    /// to organize AWS resources for a range of purposes. This operation handles the permissions
    /// necessary to manage tags for the following GameLift resource types:
    /// 
    ///  <ul><li><para>
    /// Build
    /// </para></li><li><para>
    /// Script
    /// </para></li><li><para>
    /// Fleet
    /// </para></li><li><para>
    /// Alias
    /// </para></li><li><para>
    /// GameSessionQueue
    /// </para></li><li><para>
    /// MatchmakingConfiguration
    /// </para></li><li><para>
    /// MatchmakingRuleSet
    /// </para></li></ul><para>
    /// To list tags for a resource, specify the unique ARN value for the resource.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
    /// AWS Resources</a> in the <i>AWS General Reference</i></para><para><a href="http://aws.amazon.com/answers/account-management/aws-tagging-strategies/">
    /// AWS Tagging Strategies</a></para><para><b>Related actions</b></para><para><a>TagResource</a> | <a>UntagResource</a> | <a>ListTagsForResource</a> | <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("Get", "GMLResourceTag")]
    [OutputType("Amazon.GameLift.Model.Tag")]
    [AWSCmdlet("Calls the Amazon GameLift Service ListTagsForResource API operation.", Operation = new[] {"ListTagsForResource"}, SelectReturnType = typeof(Amazon.GameLift.Model.ListTagsForResourceResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.Tag or Amazon.GameLift.Model.ListTagsForResourceResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.Tag objects.",
        "The service call response (type Amazon.GameLift.Model.ListTagsForResourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLResourceTagCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceARN
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (<a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// that is assigned to and uniquely identifies the GameLift resource that you want to
        /// retrieve tags for. GameLift resource ARNs are included in the data object for the
        /// resource, which can be retrieved by calling a List or Describe operation for the resource
        /// type. </para>
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
        public System.String ResourceARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Tags'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.ListTagsForResourceResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.ListTagsForResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Tags";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceARN' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.ListTagsForResourceResponse, GetGMLResourceTagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceARN = this.ResourceARN;
            #if MODULAR
            if (this.ResourceARN == null && ParameterWasBound(nameof(this.ResourceARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLift.Model.ListTagsForResourceRequest();
            
            if (cmdletContext.ResourceARN != null)
            {
                request.ResourceARN = cmdletContext.ResourceARN;
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
        
        private Amazon.GameLift.Model.ListTagsForResourceResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.ListTagsForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "ListTagsForResource");
            try
            {
                #if DESKTOP
                return client.ListTagsForResource(request);
                #elif CORECLR
                return client.ListTagsForResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceARN { get; set; }
            public System.Func<Amazon.GameLift.Model.ListTagsForResourceResponse, GetGMLResourceTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Tags;
        }
        
    }
}
