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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Returns information about merge conflicts between the before and after commit IDs
    /// for a pull request in a repository.<br/><br/>In the AWS.Tools.CodeCommit module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CCMergeConflict")]
    [OutputType("Amazon.CodeCommit.Model.GetMergeConflictsResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit GetMergeConflicts API operation.", Operation = new[] {"GetMergeConflicts"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.GetMergeConflictsResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.GetMergeConflictsResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.GetMergeConflictsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCCMergeConflictCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter ConflictDetailLevel
        /// <summary>
        /// <para>
        /// <para>The level of conflict detail to use. If unspecified, the default FILE_LEVEL is used,
        /// which returns a not-mergeable result if the same file has differences in both branches.
        /// If LINE_LEVEL is specified, a conflict is considered not mergeable if the same file
        /// in both branches has differences on the same line.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeCommit.ConflictDetailLevelTypeEnum")]
        public Amazon.CodeCommit.ConflictDetailLevelTypeEnum ConflictDetailLevel { get; set; }
        #endregion
        
        #region Parameter ConflictResolutionStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies which branch to use when resolving conflicts, or whether to attempt automatically
        /// merging two versions of a file. The default is NONE, which requires any conflicts
        /// to be resolved manually before the merge operation is successful.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeCommit.ConflictResolutionStrategyTypeEnum")]
        public Amazon.CodeCommit.ConflictResolutionStrategyTypeEnum ConflictResolutionStrategy { get; set; }
        #endregion
        
        #region Parameter DestinationCommitSpecifier
        /// <summary>
        /// <para>
        /// <para>The branch, tag, HEAD, or other fully qualified reference used to identify a commit
        /// (for example, a branch name or a full commit ID).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DestinationCommitSpecifier { get; set; }
        #endregion
        
        #region Parameter MaxConflictFile
        /// <summary>
        /// <para>
        /// <para>The maximum number of files to include in the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxConflictFiles")]
        public System.Int32? MaxConflictFile { get; set; }
        #endregion
        
        #region Parameter MergeOption
        /// <summary>
        /// <para>
        /// <para>The merge option or strategy you want to use to merge the code. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeCommit.MergeOptionTypeEnum")]
        public Amazon.CodeCommit.MergeOptionTypeEnum MergeOption { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where the pull request was created.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter SourceCommitSpecifier
        /// <summary>
        /// <para>
        /// <para>The branch, tag, HEAD, or other fully qualified reference used to identify a commit
        /// (for example, a branch name or a full commit ID).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceCommitSpecifier { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An enumeration token that, when provided in a request, returns the next batch of the
        /// results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.CodeCommit module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.GetMergeConflictsResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.GetMergeConflictsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RepositoryName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
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
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.GetMergeConflictsResponse, GetCCMergeConflictCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RepositoryName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConflictDetailLevel = this.ConflictDetailLevel;
            context.ConflictResolutionStrategy = this.ConflictResolutionStrategy;
            context.DestinationCommitSpecifier = this.DestinationCommitSpecifier;
            #if MODULAR
            if (this.DestinationCommitSpecifier == null && ParameterWasBound(nameof(this.DestinationCommitSpecifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationCommitSpecifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxConflictFile = this.MaxConflictFile;
            context.MergeOption = this.MergeOption;
            #if MODULAR
            if (this.MergeOption == null && ParameterWasBound(nameof(this.MergeOption)))
            {
                WriteWarning("You are passing $null as a value for parameter MergeOption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceCommitSpecifier = this.SourceCommitSpecifier;
            #if MODULAR
            if (this.SourceCommitSpecifier == null && ParameterWasBound(nameof(this.SourceCommitSpecifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceCommitSpecifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CodeCommit.Model.GetMergeConflictsRequest();
            
            if (cmdletContext.ConflictDetailLevel != null)
            {
                request.ConflictDetailLevel = cmdletContext.ConflictDetailLevel;
            }
            if (cmdletContext.ConflictResolutionStrategy != null)
            {
                request.ConflictResolutionStrategy = cmdletContext.ConflictResolutionStrategy;
            }
            if (cmdletContext.DestinationCommitSpecifier != null)
            {
                request.DestinationCommitSpecifier = cmdletContext.DestinationCommitSpecifier;
            }
            if (cmdletContext.MaxConflictFile != null)
            {
                request.MaxConflictFiles = cmdletContext.MaxConflictFile.Value;
            }
            if (cmdletContext.MergeOption != null)
            {
                request.MergeOption = cmdletContext.MergeOption;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.SourceCommitSpecifier != null)
            {
                request.SourceCommitSpecifier = cmdletContext.SourceCommitSpecifier;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeCommit.Model.GetMergeConflictsRequest();
            
            if (cmdletContext.ConflictDetailLevel != null)
            {
                request.ConflictDetailLevel = cmdletContext.ConflictDetailLevel;
            }
            if (cmdletContext.ConflictResolutionStrategy != null)
            {
                request.ConflictResolutionStrategy = cmdletContext.ConflictResolutionStrategy;
            }
            if (cmdletContext.DestinationCommitSpecifier != null)
            {
                request.DestinationCommitSpecifier = cmdletContext.DestinationCommitSpecifier;
            }
            if (cmdletContext.MaxConflictFile != null)
            {
                request.MaxConflictFiles = cmdletContext.MaxConflictFile.Value;
            }
            if (cmdletContext.MergeOption != null)
            {
                request.MergeOption = cmdletContext.MergeOption;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.SourceCommitSpecifier != null)
            {
                request.SourceCommitSpecifier = cmdletContext.SourceCommitSpecifier;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeCommit.Model.GetMergeConflictsResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.GetMergeConflictsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "GetMergeConflicts");
            try
            {
                #if DESKTOP
                return client.GetMergeConflicts(request);
                #elif CORECLR
                return client.GetMergeConflictsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CodeCommit.ConflictDetailLevelTypeEnum ConflictDetailLevel { get; set; }
            public Amazon.CodeCommit.ConflictResolutionStrategyTypeEnum ConflictResolutionStrategy { get; set; }
            public System.String DestinationCommitSpecifier { get; set; }
            public System.Int32? MaxConflictFile { get; set; }
            public Amazon.CodeCommit.MergeOptionTypeEnum MergeOption { get; set; }
            public System.String NextToken { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String SourceCommitSpecifier { get; set; }
            public System.Func<Amazon.CodeCommit.Model.GetMergeConflictsResponse, GetCCMergeConflictCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
