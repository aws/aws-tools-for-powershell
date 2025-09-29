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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Creates a new component that can be used to build, validate, test, and assess your
    /// image. The component is based on a YAML document that you specify using exactly one
    /// of the following methods:
    /// 
    ///  <ul><li><para>
    /// Inline, using the <c>data</c> property in the request body.
    /// </para></li><li><para>
    /// A URL that points to a YAML document file stored in Amazon S3, using the <c>uri</c>
    /// property in the request body.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "EC2IBComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder CreateComponent API operation.", Operation = new[] {"CreateComponent"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.CreateComponentResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.CreateComponentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.CreateComponentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IBComponentCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChangeDescription
        /// <summary>
        /// <para>
        /// <para>The change description of the component. Describes what change has been made in this
        /// version, or what makes this version different from other versions of the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChangeDescription { get; set; }
        #endregion
        
        #region Parameter Data
        /// <summary>
        /// <para>
        /// <para>Component <c>data</c> contains inline YAML document content for the component. Alternatively,
        /// you can specify the <c>uri</c> of a YAML document file stored in Amazon S3. However,
        /// you cannot specify both properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Data { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Describes the contents of the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the KMS key used to encrypt
        /// this component. This can be either the Key ARN or the Alias ARN. For more information,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-ARN">Key
        /// identifiers (KeyId)</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the component.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The operating system platform of the component.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Imagebuilder.Platform")]
        public Amazon.Imagebuilder.Platform Platform { get; set; }
        #endregion
        
        #region Parameter SemanticVersion
        /// <summary>
        /// <para>
        /// <para>The semantic version of the component. This version follows the semantic version syntax.</para><note><para>The semantic version has four nodes: &lt;major&gt;.&lt;minor&gt;.&lt;patch&gt;/&lt;build&gt;.
        /// You can assign values for the first three, and can filter on all of them.</para><para><b>Assignment:</b> For the first three nodes you can assign any positive integer
        /// value, including zero, with an upper limit of 2^30-1, or 1073741823 for each node.
        /// Image Builder automatically assigns the build number to the fourth node.</para><para><b>Patterns:</b> You can use any numeric pattern that adheres to the assignment requirements
        /// for the nodes that you can assign. For example, you might choose a software version
        /// pattern, such as 1.0.0, or a date, such as 2021.01.01.</para></note>
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
        public System.String SemanticVersion { get; set; }
        #endregion
        
        #region Parameter SupportedOsVersion
        /// <summary>
        /// <para>
        /// <para>The operating system (OS) version supported by the component. If the OS information
        /// is available, a prefix match is performed against the base image OS version during
        /// image recipe creation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedOsVersions")]
        public System.String[] SupportedOsVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that apply to the component.</para><para />
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
        
        #region Parameter Uri
        /// <summary>
        /// <para>
        /// <para>The <c>uri</c> of a YAML component document file. This must be an S3 URL (<c>s3://bucket/key</c>),
        /// and the requester must have permission to access the S3 bucket it points to. If you
        /// use Amazon S3, you can specify component content up to your service quota.</para><para>Alternatively, you can specify the YAML document inline, using the component <c>data</c>
        /// property. You cannot specify both properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Uri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComponentBuildVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.CreateComponentResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.CreateComponentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComponentBuildVersionArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IBComponent (CreateComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.CreateComponentResponse, NewEC2IBComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeDescription = this.ChangeDescription;
            context.ClientToken = this.ClientToken;
            context.Data = this.Data;
            context.Description = this.Description;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Platform = this.Platform;
            #if MODULAR
            if (this.Platform == null && ParameterWasBound(nameof(this.Platform)))
            {
                WriteWarning("You are passing $null as a value for parameter Platform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SemanticVersion = this.SemanticVersion;
            #if MODULAR
            if (this.SemanticVersion == null && ParameterWasBound(nameof(this.SemanticVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter SemanticVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SupportedOsVersion != null)
            {
                context.SupportedOsVersion = new List<System.String>(this.SupportedOsVersion);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Uri = this.Uri;
            
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
            var request = new Amazon.Imagebuilder.Model.CreateComponentRequest();
            
            if (cmdletContext.ChangeDescription != null)
            {
                request.ChangeDescription = cmdletContext.ChangeDescription;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Data != null)
            {
                request.Data = cmdletContext.Data;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.SemanticVersion != null)
            {
                request.SemanticVersion = cmdletContext.SemanticVersion;
            }
            if (cmdletContext.SupportedOsVersion != null)
            {
                request.SupportedOsVersions = cmdletContext.SupportedOsVersion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Uri != null)
            {
                request.Uri = cmdletContext.Uri;
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
        
        private Amazon.Imagebuilder.Model.CreateComponentResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.CreateComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "CreateComponent");
            try
            {
                return client.CreateComponentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChangeDescription { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Data { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public Amazon.Imagebuilder.Platform Platform { get; set; }
            public System.String SemanticVersion { get; set; }
            public List<System.String> SupportedOsVersion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Uri { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.CreateComponentResponse, NewEC2IBComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComponentBuildVersionArn;
        }
        
    }
}
