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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// A list of the channels moderated by an <c>AppInstanceUser</c>.
    /// 
    ///  <note><para>
    /// The <c>x-amz-chime-bearer</c> request header is mandatory. Use the <c>AppInstanceUserArn</c>
    /// of the user that makes the API call as the value in the header.
    /// </para></note><important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_messaging-chime_ListChannelsModeratedByAppInstanceUser.html">ListChannelsModeratedByAppInstanceUser</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "CHMChannelsModeratedByAppInstanceUserList")]
    [OutputType("Amazon.Chime.Model.ChannelModeratedByAppInstanceUserSummary")]
    [AWSCmdlet("Calls the Amazon Chime ListChannelsModeratedByAppInstanceUser API operation.", Operation = new[] {"ListChannelsModeratedByAppInstanceUser"}, SelectReturnType = typeof(Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.ChannelModeratedByAppInstanceUserSummary or Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse",
        "This cmdlet returns a collection of Amazon.Chime.Model.ChannelModeratedByAppInstanceUserSummary objects.",
        "The service call response (type Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by ListChannelsModeratedByAppInstanceUser in the Amazon Chime SDK Messaging Namespace")]
    public partial class GetCHMChannelsModeratedByAppInstanceUserListCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppInstanceUserArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the user in the moderated channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AppInstanceUserArn { get; set; }
        #endregion
        
        #region Parameter ChimeBearer
        /// <summary>
        /// <para>
        /// <para>The <c>AppInstanceUserArn</c> of the user that makes the API call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChimeBearer { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of channels in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned from previous API requests until the number of channels moderated
        /// by the user is reached.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Channels'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Channels";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse, GetCHMChannelsModeratedByAppInstanceUserListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppInstanceUserArn = this.AppInstanceUserArn;
            context.ChimeBearer = this.ChimeBearer;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserRequest();
            
            if (cmdletContext.AppInstanceUserArn != null)
            {
                request.AppInstanceUserArn = cmdletContext.AppInstanceUserArn;
            }
            if (cmdletContext.ChimeBearer != null)
            {
                request.ChimeBearer = cmdletContext.ChimeBearer;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "ListChannelsModeratedByAppInstanceUser");
            try
            {
                return client.ListChannelsModeratedByAppInstanceUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChimeBearer { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Chime.Model.ListChannelsModeratedByAppInstanceUserResponse, GetCHMChannelsModeratedByAppInstanceUserListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Channels;
        }
        
    }
}
