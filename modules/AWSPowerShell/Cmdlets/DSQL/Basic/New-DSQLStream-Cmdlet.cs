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
using Amazon.DSQL;
using Amazon.DSQL.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DSQL
{
    /// <summary>
    /// Creates a new change data capture (CDC) stream for a cluster. The stream captures
    /// database changes and delivers them to the specified target destination.
    /// 
    ///  
    /// <para><b>Required permissions</b></para><dl><dt>dsql:CreateStream</dt><dd><para>
    /// Permission to create a new stream.
    /// </para><para>
    /// Resources: <c>arn:aws:dsql:region:account-id:cluster/cluster-id</c></para></dd><dt>iam:PassRole</dt><dd><para>
    /// Permission to pass the IAM role specified in the target definition to the service.
    /// </para><para>
    /// Resources: ARN of the IAM role specified in <c>targetDefinition.kinesis.roleArn</c></para></dd><dt>kms:Decrypt</dt><dd><para>
    /// Required when the cluster uses a customer managed KMS key (CMK). Permission to decrypt
    /// data using the cluster's CMK.
    /// </para><para>
    /// Resources: ARN of the KMS key used by the cluster
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("New", "DSQLStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DSQL.Model.CreateStreamResponse")]
    [AWSCmdlet("Calls the Amazon Aurora DSQL CreateStream API operation.", Operation = new[] {"CreateStream"}, SelectReturnType = typeof(Amazon.DSQL.Model.CreateStreamResponse))]
    [AWSCmdletOutput("Amazon.DSQL.Model.CreateStreamResponse",
        "This cmdlet returns an Amazon.DSQL.Model.CreateStreamResponse object containing multiple properties."
    )]
    public partial class NewDSQLStreamCmdlet : AmazonDSQLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the cluster for which to create the stream.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the stream records.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DSQL.StreamFormat")]
        public Amazon.DSQL.StreamFormat Format { get; set; }
        #endregion
        
        #region Parameter Ordering
        /// <summary>
        /// <para>
        /// <para>The ordering mode for the stream. Determines how change events are ordered when delivered
        /// to the target.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DSQL.StreamOrdering")]
        public Amazon.DSQL.StreamOrdering Ordering { get; set; }
        #endregion
        
        #region Parameter TargetDefinition_Kinesis_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants permission to write to the Kinesis stream. This
        /// can be a standard role (<c>arn:aws:iam::account-id:role/role-name</c>) or a role with
        /// a path prefix (<c>arn:aws:iam::account-id:role/service-role/role-name</c>), such as
        /// roles auto-created by the console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDefinition_Kinesis_RoleArn { get; set; }
        #endregion
        
        #region Parameter TargetDefinition_Kinesis_StreamArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Kinesis stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDefinition_Kinesis_StreamArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of key and value pairs to use to tag your stream.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, the subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect.</para><para>If you don't specify a client token, the Amazon Web Services SDK automatically generates
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DSQL.Model.CreateStreamResponse).
        /// Specifying the name of a property of type Amazon.DSQL.Model.CreateStreamResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSQLStream (CreateStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DSQL.Model.CreateStreamResponse, NewDSQLStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ordering = this.Ordering;
            #if MODULAR
            if (this.Ordering == null && ParameterWasBound(nameof(this.Ordering)))
            {
                WriteWarning("You are passing $null as a value for parameter Ordering which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.TargetDefinition_Kinesis_RoleArn = this.TargetDefinition_Kinesis_RoleArn;
            context.TargetDefinition_Kinesis_StreamArn = this.TargetDefinition_Kinesis_StreamArn;
            
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
            var request = new Amazon.DSQL.Model.CreateStreamRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.Ordering != null)
            {
                request.Ordering = cmdletContext.Ordering;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TargetDefinition
            var requestTargetDefinitionIsNull = true;
            request.TargetDefinition = new Amazon.DSQL.Model.TargetDefinition();
            Amazon.DSQL.Model.KinesisTargetDefinition requestTargetDefinition_targetDefinition_Kinesis = null;
            
             // populate Kinesis
            var requestTargetDefinition_targetDefinition_KinesisIsNull = true;
            requestTargetDefinition_targetDefinition_Kinesis = new Amazon.DSQL.Model.KinesisTargetDefinition();
            System.String requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_RoleArn = null;
            if (cmdletContext.TargetDefinition_Kinesis_RoleArn != null)
            {
                requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_RoleArn = cmdletContext.TargetDefinition_Kinesis_RoleArn;
            }
            if (requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_RoleArn != null)
            {
                requestTargetDefinition_targetDefinition_Kinesis.RoleArn = requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_RoleArn;
                requestTargetDefinition_targetDefinition_KinesisIsNull = false;
            }
            System.String requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_StreamArn = null;
            if (cmdletContext.TargetDefinition_Kinesis_StreamArn != null)
            {
                requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_StreamArn = cmdletContext.TargetDefinition_Kinesis_StreamArn;
            }
            if (requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_StreamArn != null)
            {
                requestTargetDefinition_targetDefinition_Kinesis.StreamArn = requestTargetDefinition_targetDefinition_Kinesis_targetDefinition_Kinesis_StreamArn;
                requestTargetDefinition_targetDefinition_KinesisIsNull = false;
            }
             // determine if requestTargetDefinition_targetDefinition_Kinesis should be set to null
            if (requestTargetDefinition_targetDefinition_KinesisIsNull)
            {
                requestTargetDefinition_targetDefinition_Kinesis = null;
            }
            if (requestTargetDefinition_targetDefinition_Kinesis != null)
            {
                request.TargetDefinition.Kinesis = requestTargetDefinition_targetDefinition_Kinesis;
                requestTargetDefinitionIsNull = false;
            }
             // determine if request.TargetDefinition should be set to null
            if (requestTargetDefinitionIsNull)
            {
                request.TargetDefinition = null;
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
        
        private Amazon.DSQL.Model.CreateStreamResponse CallAWSServiceOperation(IAmazonDSQL client, Amazon.DSQL.Model.CreateStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Aurora DSQL", "CreateStream");
            try
            {
                return client.CreateStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public Amazon.DSQL.StreamFormat Format { get; set; }
            public Amazon.DSQL.StreamOrdering Ordering { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TargetDefinition_Kinesis_RoleArn { get; set; }
            public System.String TargetDefinition_Kinesis_StreamArn { get; set; }
            public System.Func<Amazon.DSQL.Model.CreateStreamResponse, NewDSQLStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
